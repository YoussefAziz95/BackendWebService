using Application.Contracts.Persistence;
using Application.Features;
using Application.Model.EAVEngine;
using Application.Model.Notifications;
using Domain;
using Domain;
using Domain.Enums;
using Persistence.Data;
using Persistence.Repositories.Common;
using Persistence.Repositories.WorkflowReviewRepositories;

namespace Persistence.Repositories.Workflows
{
    public class CaseActionRepository : GenericRepository<CaseAction>, ICaseActionRepository
    {

        // DbContext instance
        protected readonly ApplicationDbContext _context;
        private IWorkflowReviewRepositoryFactory<Case,WorkflowCycle> _actionObjectRepositoryFactory;
        private readonly string WORKFLOW_CYCLE = "WorkflowCycle";
        private readonly string WORKFLOW_ACTION = "CaseAction";
        public CaseActionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public int AddNeactionActor(Case wcase)
        {
            var result = -1;
            var cycle = _context.Set<WorkflowCycle>().First(w => w.ActionOrder == wcase.ActionIndex && w.WorkflowId == wcase.WorkflowId);
            var caseAction = new CaseAction()
            {
                StatusId = (int)StatusEnum.New,
                Order = wcase.ActionIndex,
                CaseId = wcase.Id,
                WorkflowCycleId = cycle.Id

            };

            _context.Add(caseAction);
            result = _context.SaveChanges();
            var cycleActor = _context.Set<Actor>().First(a => a.OwnerId == cycle.Id && a.OwnerType == WORKFLOW_CYCLE);
            var actor = new Actor()
            {
                ActorId = cycleActor.ActorId,
                ActorType = cycleActor.ActorType,
                OwnerType = WORKFLOW_ACTION,
                OwnerId = caseAction.Id,
            };
            _context.Add(actor);
            return caseAction.Id;
        }
        public int TakeAction(TakeActionModel actionModel)
        {
            var caseActionId = -1;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var action = _context.Set<CaseAction>().First(a => a.Id == actionModel.Id);
                    var actionObject = _context.Set<ActionObject>().First(wr => wr.ActionId == action.Id && wr.ActionType == WORKFLOW_ACTION);
                    actionModel.Id = actionObject.ObjectId;
                    _actionObjectRepositoryFactory = new WorkflowReviewRepositoryFactory<Case,WorkflowCycle>(_context, actionObject.ObjectType);
                    var wcase = _context.Set<Case>().First(c => c.Id == action.CaseId);
                    int CycleCount = _context.Set<WorkflowCycle>().Count(c => c.WorkflowId == wcase.WorkflowId);

                    wcase.ActionIndex = (action.Order ?? 0) + 1;
                    if (actionModel.StatusId == 0)
                        action.StatusId = (int)StatusEnum.Accepted;
                    else
                        action.StatusId = actionModel.StatusId;

                    _context.Update(action);

                    if (actionModel.StatusId == (int)StatusEnum.Returned)
                        wcase.StatusId = actionModel.StatusId;

                    else if (action.StatusId == (int)StatusEnum.Accepted)

                        if (wcase.ActionIndex <= CycleCount)
                        {
                            _actionObjectRepositoryFactory.UpdateObjectModel(actionModel, false);
                            caseActionId = AddNeactionActor(wcase);
                            var actionNext = _context.Set<CaseAction>().First(a => a.Id == caseActionId);
                            var cycle = _context.Set<WorkflowCycle>().First(c => c.Id == actionNext.WorkflowCycleId);
                            var objectId = _actionObjectRepositoryFactory.GetNextModel(wcase, cycle);
                            ActionObject actionObjectAction = new ActionObject()
                            {
                                ActionId = caseActionId,
                                ActionType = WORKFLOW_ACTION,
                                ObjectId = objectId,
                                ObjectType = actionObject.ObjectType
                            };
                            _context.Add(actionObjectAction);
                        }
                    if (wcase.ActionIndex > CycleCount)
                    {
                        _actionObjectRepositoryFactory.UpdateObjectModel(actionModel, true);
                        wcase.StatusId = action.StatusId;
                    }

                    _context.Set<Case>().Update(wcase);
                    _context.SaveChanges();
                    transaction.Commit();
                    return action.Id;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    return caseActionId;
                }
            }
        }
        public IQueryable<UserInfo> GetUsers()
        {

            var users = from u in _context.Users
                        join ug in _context.Set<UserGroup>() on u.Id equals ug.UserId into userGroups
                        from ug in userGroups.DefaultIfEmpty()
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        select new UserInfo
                        {
                            ConnectionId = u.Id.ToString(),
                            Username = u.UserName,
                            UserId = u.Id,
                            GroupId = ug.GroupId,
                            RoleId = ur.RoleId
                        };
            return users;
        }
        public List<CaseActionsResponse> GetActionsByUserId(int userId)
        {
            var userClient = GetUsers().Where(u => u.UserId == _context.userInfo.UserId).Distinct().First();
            var user = _context.Users.Where(u => u.Id == _context.userInfo.UserId).First();

            var query = from wcase in _context.Set<Case>()
                        join actions in _context.Set<CaseAction>().Where(a => a.StatusId == (int)StatusEnum.New) on wcase.Id equals actions.CaseId
                        join actors in _context.Set<Actor>().Where(a => a.OwnerType == "CaseAction") on actions.Id equals actors.OwnerId
                        join actionObject in _context.Set<ActionObject>().Where(wr => wr.ActionType == "CaseAction") on actions.Id equals actionObject.ActionId
                        join organiztations in _context.Set<Organization>() on wcase.OrganizationId equals organiztations.Id
                        join workflowCycle in _context.Set<WorkflowCycle>() on actions.WorkflowCycleId equals workflowCycle.Id
                        join requester in _context.Users on wcase.UserId equals requester.Id
                        select new CaseActionRecord
                        (actions.Id, actors.ActorType, actors.ActorId, requester.FirstName + " " + requester.LastName, organiztations.Name, actions.CaseId, actionObject.ObjectType, actionObject.ObjectId, workflowCycle.ActionType);
            var list = query.Distinct().ToList();
            var userActions =
            from q in list.Where(a => a.AssignedOnType == "Customer")
            where q.AssignedOnId == _context.userInfo.UserId
            select q;

            var groupActions =
            from q in list.Where(a => a.AssignedOnType == "Group")
            join ug in _context.Set<UserGroup>().Where(g => g.UserId == _context.userInfo.UserId) on q.AssignedOnId equals ug.GroupId
            select new CaseActionRecord
                       (q.Id, q.AssignedOnType, q.AssignedOnId, q.RequesterName, q.CompanySupplierName, q.CaseId, q.CaseType, q.CaseName, q.ActionType);

            var roleActions =
            from q in list.Where(a => a.AssignedOnType == "ApplicationRole")
            join ug in _context.UserRoles.Where(g => g.UserId == _context.userInfo.UserId) on q.AssignedOnId equals ug.RoleId
            select new CaseActionRecord
                       (q.Id, q.AssignedOnType, q.AssignedOnId, q.RequesterName, q.CompanySupplierName, q.CaseId, q.CaseType, q.CaseName, q.ActionType);

            // Combine user actions and role names into one collection
            var actionsList = userActions.ToList();
            actionsList.AddRange(groupActions.ToList());
            actionsList.AddRange(roleActions.ToList());
            List<CaseActionsResponse> actionsResponse = new List<CaseActionsResponse>();

            foreach (var action in actionsList.Distinct())
            {
                _actionObjectRepositoryFactory = new WorkflowReviewRepositoryFactory<Case, WorkflowCycle>(_context, action.CaseType);
                var actionReponse = new CaseActionsResponse(
                    Id : action.Id,
                    AssignedOnName : action.AssignedOnId.ToString(),
                    AssignedOnType : action.AssignedOnType,
                    RequesterName : action.RequesterName,
                    OrganizationName : action.CompanySupplierName,
                    CaseId : action.CaseId,
                    CaseType : action.CaseType,
                    CaseName : _actionObjectRepositoryFactory.GetObjectModel(action.CaseName).ObjectName,
                    ActionType : action.ActionType,
                    ActionName: action.ActionType // ????????????????
                );
                actionsResponse.Add(actionReponse);

            }


            return actionsResponse;

        }
        public record CaseActionRecord(
            int Id,
            string AssignedOnType,
            int AssignedOnId,
            string RequesterName,
            string CompanySupplierName,
            int CaseId,
            string CaseType,
            int CaseName,
            string ActionType
        );
        private User Getuser(int userId)
        {

            var user = _context.Users.First(u => u.Id == userId);
            user.OrganizationId = _context.Set<Organization>().First(c => c.Id == user.OrganizationId).Id;
            if (user is null)
                return new User();
            return user;
        }
        public ActionResponse GetAsync(int id, int userId)
        {
            var query = from act in _context.Set<CaseAction>()
                        join wcase in _context.Set<Case>() on act.CaseId equals wcase.Id
                        join cycle in _context.Set<WorkflowCycle>() on act.WorkflowCycleId equals cycle.Id
                        join requester in _context.Set<User>() on wcase.UserId equals requester.Id
                        join wreview in _context.Set<ActionObject>() on new { ActionId = act.Id, ActionType = WORKFLOW_ACTION } equals new { wreview.ActionId, wreview.ActionType }
                        where act.Id == id
                        select new { act, wcase, cycle, requester, wreview };
            var action = query.First();
            var assignee = Getuser(userId);
            _actionObjectRepositoryFactory = new WorkflowReviewRepositoryFactory<Case, WorkflowCycle>(_context, action.wreview.ObjectType);
            var objectModel = _actionObjectRepositoryFactory.GetObjectModel(action.wreview.ObjectId);


            var actionsResponse = new ActionResponse(
                Id : id,
                WorkflowId : action.cycle.WorkflowId,
                RequesterId: action.requester.Id,
                CaseId : action.wcase.Id,
                RequesterCompany : _context.Set<Organization>().First(key => key.Id == action.requester.OrganizationId).Name,
                RequesterDepartment : action.requester.Department,
                RequesterEmail : action.requester.Email,
                RequesterFullname : action.requester.FirstName + " " + action.requester.LastName,
                RequesterUsername : action.requester.UserName,
                AssignedOnId : assignee.Id,
                AssignedOnCompany : _context.Set<Organization>().First(key => key.Id == assignee.OrganizationId).Name,
                AssignedOnDepartment : assignee.Department,
                AssignedOnEmail : assignee.Email,
                AssignedOnFullname : assignee.FirstName + " " + assignee.LastName,
                AssignedOnUsername : assignee.UserName,
                AssignedAt : action.act.CreatedDate,
                ActionStatus : Enum.GetName(typeof(ActionEnum), action.act.StatusId),
                CaseStatus : action.wcase.StatusId,
                Comment : objectModel.ObjectName, // ??????????????????????,
                ActionType : action.cycle.ActionType,
                ObjectName : objectModel.ObjectName,
                FileId: objectModel.FileId,
                ObjectType : action.wreview.ObjectType,
                ObjectId : objectModel.ObjectId


            );
            return actionsResponse;
        }

      
        List<CaseActionsResponse> ICaseActionRepository.GetActionsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        ActionResponse ICaseActionRepository.GetAsync(int id, int userId)
        {
            throw new NotImplementedException();
        }
    }

}
