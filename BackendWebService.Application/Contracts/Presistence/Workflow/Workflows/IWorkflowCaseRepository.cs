namespace Application.Contracts.Persistence
{
    public interface ICaseRepository
    {
        Case OpenCase(int workflowId, int companySupplierId);
    }
}
