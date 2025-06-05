using Application.Features;
using Application.Model.EAVEngine;
using Domain;

namespace Application.Contracts.Persistence
{
    public interface IWorkflowActionRepository
    {
        int AddNewAction(WorkflowCase workflowCase);
        int TakeAction(TakeActionModel reviewObjectModel);
        List<WorkflowActionsResponse> GetActionsByUserId(int userId);
        ActionResponse GetAsync(int id, int userId);
    }
}
