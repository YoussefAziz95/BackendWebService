using Application.Model.EAVEngine;

namespace Application.Contracts.Presistence.WorkflowReviewRepositories
{
    public interface IWorkflowReviewRepositoryFactory<TCase, TCycle>
    {
        string GetObjectType(int id);
        TakeActionModel GetObjectModel(int id);
        int UpdateObjectModel(TakeActionModel reviewObjectModel, bool finalAction);
        int GetNextModel(TCase workflowCycle, TCycle workflowCase);
    }
}
