using Application.Features;
namespace Application.Contracts;

public interface IWorkflowRepository
{
    int UpdateWorkflow(Workflow updatedEntity, ActionObject actionObject, List<ActionObject> workflowActorObjects, List<Actor> workflowCycleActors);


    int AddWorkflowAsync(Workflow fullEntity, ActionObject actionObject, List<ActionObject> workflowActorObjects, List<Actor> workflowCycleActors);

    Workflow GetById(int id);

    List<WorkflowAllResponse> GetPaginated(WorkflowAllRequest request);

    WorkflowResponse GetWorkflowById(int id);
}
