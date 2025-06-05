using Domain;
using Application.Features;
using Application.Model.EAVEngine;

namespace Application.Contracts;

public interface IWorkflowCycleRepository
{
    int AddWorklfowCycleRange(List<WorkflowCycle> workflowCycles, List<ActorModel> actorModels, List<WorkflowReview> workflowReviews, int WorkflowId);


    IEnumerable<WorkflowCycleResponse> GetAll(int workflowId, string name);

}
