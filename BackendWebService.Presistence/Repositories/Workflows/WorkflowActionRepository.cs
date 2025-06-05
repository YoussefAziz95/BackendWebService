using Application.Contracts.Persistence;
using Application.Features;
using Application.Model.EAVEngine;
using Application.Model.Notifications;
using Domain;
using Domain.Enums;
using Persistence.Data;
using Persistence.Repositories.Common;
using Persistence.Repositories.WorkflowReviewRepositories;

namespace Persistence.Repositories.Workflows
{
    public class WorkflowActionRepository : GenericRepository<WorkflowAction>, IWorkflowActionRepository
    {

        // DbContext instance
        protected readonly ApplicationDbContext _context;
        private IWorkflowReviewRepositoryFactory<WorkflowCase,WorkflowCycle> _workflowReviewRepositoryFactory;
        private readonly string WORKFLOW_CYCLE = "WorkflowCycle";
        private readonly string WORKFLOW_ACTION = "WorkflowAction";
        public WorkflowActionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public int AddNewAction(WorkflowCase workflowCase)
        {
            var result = -1;
            var cycle = _context.Set<WorkflowCycle>().First(w => w.ActionOrder == workflowCase.ActionIndex && w.WorkflowId == workflowCase.WorkflowId);
            var workflowAction = new WorkflowAction()
            {
                StatusId = (int)StatusEnum.New,
                Order = workflowCase.ActionIndex,
                WorkflowCaseId = workflowCase.Id,
                WorkflowCycleId = cycle.Id

            };

            _context.Add(workflowAction);
            result = _context.SaveChanges();
            var cycleActor = _context.Set<Actor>().First(a => a.OwnerId == cycle.Id && a.OwnerType == WORKFLOW_CYCLE);
            var actor = new Actor()
            {
                ActorId = cycleActor.ActorId,
                ActorType = cycleActor.ActorType,
                OwnerType = WORKFLOW_ACTION,
                OwnerId = workflowAction.Id,
            };
            _context.Add(actor);
            return workflowAction.Id;
        }
        public int TakeAction(TakeActionModel actionModel)
        {
            var workflowActionId = -1;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var action = _context.Set<WorkflowAction>().First(a => a.Id == actionModel.Id);
                    var workflowReview = _context.Set<WorkflowReview>().First(wr => wr.OwnerId == action.Id && wr.OwnerType == WORKFLOW_ACTION);
                    actionModel.Id = workflowReview.ObjectId;
                    _workflowReviewRepositoryFactory = new WorkflowReviewRepositoryFactory<WorkflowCase,WorkflowCycle>(_context, workflowReview.ObjectType);
                    var workflowCase = _context.Set<WorkflowCase>().First(c => c.Id == action.WorkflowCaseId);
                    int CycleCount = _context.Set<WorkflowCycle>().Count(c => c.WorkflowId == workflowCase.WorkflowId);

                    workflowCase.ActionIndex = (action.Order ?? 0) + 1;
                    if (actionModel.StatusId == 0)
                        action.StatusId = (int)StatusEnum.Accepted;
                    else
                        action.StatusId = actionModel.StatusId;

                    _context.Update(action);

                    if (actionModel.StatusId == (int)StatusEnum.Returned)
                        workflowCase.StatusId = actionModel.StatusId;

                    else if (action.StatusId == (int)StatusEnum.Accepted)

                        if (workflowCase.ActionIndex <= CycleCount)
                        {
                            _workflowReviewRepositoryFactory.UpdateObjectModel(actionModel, false);
                            workflowActionId = AddNewAction(workflowCase);
                            var actionNext = _context.Set<WorkflowAction>().First(a => a.Id == workflowActionId);
                            var cycle = _context.Set<WorkflowCycle>().First(c => c.Id == actionNext.WorkflowCycleId);
                            var objectId = _workflowReviewRepositoryFactory.GetNextModel(workflowCase, cycle);
                            WorkflowReview workflowReviewAction = new WorkflowReview()
                            {
                                OwnerId = workflowActionId,
                                OwnerType = WORKFLOW_ACTION,
                                ObjectId = objectId,
                                ObjectType = workflowReview.ObjectType
                            };
                            _context.Add(workflowReviewAction);
                        }
                    if (workflowCase.ActionIndex > CycleCount)
                    {
                        _workflowReviewRepositoryFactory.UpdateObjectModel(actionModel, true);
                        workflowCase.StatusId = action.StatusId;
                    }

                    _context.Set<WorkflowCase>().Update(workflowCase);
                    _context.SaveChanges();
                    transaction.Commit();
                    return action.Id;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    return workflowActionId;
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
        public List<WorkflowActionsResponse> GetActionsByUserId(int userId)
        {
            var userClient = GetUsers().Where(u => u.UserId == _context.userInfo.UserId).Distinct().First();
            var user = _context.Users.Where(u => u.Id == _context.userInfo.UserId).First();

            var query = from workflowCase in _context.Set<WorkflowCase>()
                        join actions in _context.Set<WorkflowAction>().Where(a => a.StatusId == (int)StatusEnum.New) on workflowCase.Id equals actions.WorkflowCaseId
                        join actors in _context.Set<Actor>().Where(a => a.OwnerType == "WorkflowAction") on actions.Id equals actors.OwnerId
                        join workflowReview in _context.Set<WorkflowReview>().Where(wr => wr.OwnerType == "WorkflowAction") on actions.Id equals workflowReview.OwnerId
                        join organiztations in _context.Set<Organization>() on workflowCase.OrganizationId equals organiztations.Id
                        join workflowCycle in _context.Set<WorkflowCycle>() on actions.WorkflowCycleId equals workflowCycle.Id
                        join requester in _context.Users on workflowCase.UserId equals requester.Id
                        select new WorkflowActionRecord
                        (actions.Id, actors.ActorType, actors.ActorId, requester.FirstName + " " + requester.LastName, organiztations.Name, actions.WorkflowCaseId, workflowReview.ObjectType, workflowReview.ObjectId, workflowCycle.ActionType);
            var list = query.Distinct().ToList();
            var userActions =
            from q in list.Where(a => a.AssignedOnType == "Customer")
            where q.AssignedOnId == _context.userInfo.UserId
            select q;

            var groupActions =
            from q in list.Where(a => a.AssignedOnType == "Group")
            join ug in _context.Set<UserGroup>().Where(g => g.UserId == _context.userInfo.UserId) on q.AssignedOnId equals ug.GroupId
            select new WorkflowActionRecord
                       (q.Id, q.AssignedOnType, q.AssignedOnId, q.RequesterName, q.CompanySupplierName, q.CaseId, q.CaseType, q.CaseName, q.ActionType);

            var roleActions =
            from q in list.Where(a => a.AssignedOnType == "ApplicationRole")
            join ug in _context.UserRoles.Where(g => g.UserId == _context.userInfo.UserId) on q.AssignedOnId equals ug.RoleId
            select new WorkflowActionRecord
                       (q.Id, q.AssignedOnType, q.AssignedOnId, q.RequesterName, q.CompanySupplierName, q.CaseId, q.CaseType, q.CaseName, q.ActionType);

            // Combine user actions and role names into one collection
            var actionsList = userActions.ToList();
            actionsList.AddRange(groupActions.ToList());
            actionsList.AddRange(roleActions.ToList());
            List<WorkflowActionsResponse> actionsResponse = new List<WorkflowActionsResponse>();

            foreach (var action in actionsList.Distinct())
            {
                _workflowReviewRepositoryFactory = new WorkflowReviewRepositoryFactory<WorkflowCase, WorkflowCycle>(_context, action.CaseType);
                var actionReponse = new WorkflowActionsResponse(
                    Id : action.Id,
                    AssignedOnName : action.AssignedOnId.ToString(),
                    AssignedOnType : action.AssignedOnType,
                    RequesterName : action.RequesterName,
                    OrganizationName : action.CompanySupplierName,
                    CaseId : action.CaseId,
                    CaseType : action.CaseType,
                    CaseName : _workflowReviewRepositoryFactory.GetObjectModel(action.CaseName).ObjectName,
                    ActionType : action.ActionType,
                    ActionName: action.ActionType // ????????????????
                );
                actionsResponse.Add(actionReponse);

            }


            return actionsResponse;

        }
        public record WorkflowActionRecord(
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
            var query = from act in _context.Set<WorkflowAction>()
                        join wcase in _context.Set<WorkflowCase>() on act.WorkflowCaseId equals wcase.Id
                        join cycle in _context.Set<WorkflowCycle>() on act.WorkflowCycleId equals cycle.Id
                        join requester in _context.Set<User>() on wcase.UserId equals requester.Id
                        join wreview in _context.Set<WorkflowReview>() on new { OwnerId = act.Id, OwnerType = WORKFLOW_ACTION } equals new { wreview.OwnerId, wreview.OwnerType }
                        where act.Id == id
                        select new { act, wcase, cycle, requester, wreview };
            var action = query.First();
            var assignee = Getuser(userId);
            _workflowReviewRepositoryFactory = new WorkflowReviewRepositoryFactory<WorkflowCase, WorkflowCycle>(_context, action.wreview.ObjectType);
            var objectModel = _workflowReviewRepositoryFactory.GetObjectModel(action.wreview.ObjectId);


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

      
        List<WorkflowActionsResponse> IWorkflowActionRepository.GetActionsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        ActionResponse IWorkflowActionRepository.GetAsync(int id, int userId)
        {
            throw new NotImplementedException();
        }
    }

}
