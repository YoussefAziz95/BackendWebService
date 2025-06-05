using Application.Features.Common;
using Domain;
using Application.Features;
namespace Application.Contracts;

public interface IWorkflowRepository
{
    Task<int> UpdateWorkflow(Workflow updatedEntity, WorkflowReview workflowReview, List<WorkflowReview> workflowCycleReviews, List<Actor> workflowCycleActors);


    Task<int> AddWorkflowAsync(Workflow fullEntity, WorkflowReview workflowReview, List<WorkflowReview> workflowCycleReviews, List<Actor> workflowCycleActors);

    Workflow GetById(int id);

    List<WorkflowAllResponse> GetPaginated(GetPaginatedRequest request);

    WorkflowResponse GetWorkflowById(int id);
}
