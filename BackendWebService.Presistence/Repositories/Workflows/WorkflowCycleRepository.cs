using Application.Contracts;
using Application.Features;
using Application.Model.EAVEngine;
using Persistence.Data;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Workflows
{
    public class WorkflowCycleRepository : GenericRepository<WorkflowCycle>, IWorkflowCycleRepository
    {

        public WorkflowCycleRepository(ApplicationDbContext context) : base(context) { }

        public int AddWorklfowCycleRange(List<WorkflowCycle> workflowCycles, List<ActorModel> actorModels, List<ActionObject> actionObjects, int WorkflowId)
        {


            //for (int i = 0; i < workflowCycles.Count; i++)
            //{
            //    _actorRepositoryFactory = new ActorRepositoryFactory(DbContext, actorModels[i].ActorTypeId);
            //    var actionObjecterId = _actorRepositoryFactory.AddActorAsync(actorModels[i]);
            //    workflowCycles[i].WorkflowReviewerId = actionObjecterId;
            //    actionObjectModels[i].WorkflowReviewTypeId = type;
            //    _actionObjectRepositoryFactory = new WorkflowReviewRepositoryFactory(DbContext, actionObjectModels[i].WorkflowReviewTypeId);
            //    var actionObjectId = _actionObjectRepositoryFactory.AddWorkflowReviewAsync(actionObjectModels[i]);
            //    workflowCycles[i].WorkflowReviewId = actionObjectId;


            //    workflowCycles[i].WorkflowId = WorkflowId;
            //}
            //AddRange(workflowCycles);
            //return workflowCycles.Count;
            throw new NotImplementedException();


        }
        public IEnumerable<WorkflowCycleResponse> GetAll(int workflowId, string name)
        {
            //var WorkflowCycles = DbContext.WorkflowCycles.Where(c => c.WorkflowId == workflowId)
            //    .Join(DbContext.actors, c => c.WorkflowReviewerId, a => a.Id,
            //    (c, a) => new WorkflowCycleResponse    // Result projection
            //    {
            //        Id = c.Id,       // Example of mapping WorkflowCycle properties
            //        WorkflowId = c.WorkflowId,
            //        ActionOrder = c.ActionOrder,
            //        Mandatory = c.Mandatory,        // Example of mapping Actors properties
            //        WorkflowReviewerId = a.Id,
            //        ActorTypeId = a.ActorTypeId,
            //        ActorTypeName = DbContext.actorTypes.First(t => t.Id == a.ActorTypeId).Name,
            //    })
            //    .ToList();
            //foreach (var item in WorkflowCycles)
            //{
            //    _actorRepositoryFactory = new ActorRepositoryFactory(DbContext, item.ActorTypeId);
            //    item.WorkflowReviewerId = _actorRepositoryFactory.GetActorId(item.WorkflowReviewerId);
            //}
            //return WorkflowCycles;
            throw new NotImplementedException();
        }

    }
}
