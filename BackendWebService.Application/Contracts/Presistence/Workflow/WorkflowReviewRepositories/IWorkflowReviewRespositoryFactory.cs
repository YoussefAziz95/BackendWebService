using Application.Model.EAVEngine;

namespace Application.Contracts.Persistence;

public interface IWorkflowReviewRepositoryFactory<TCase, TCycle>
{
    string GetObjectType(int id);
    WorkflowReviewObjectModel GetObjectModel(int id);
    int UpdateObjectModel(TakeActionModel reviewObjectModel, bool finalAction);
    int GetNextModel(TCase workflowCycle, TCycle workflowCase);
}
