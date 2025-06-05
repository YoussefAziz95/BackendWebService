using Domain;

namespace Application.Contracts.Persistence
{
    public interface IWorkflowCaseRepository
    {
        WorkflowCase OpenCase(int workflowId, int companySupplierId);
    }
}
