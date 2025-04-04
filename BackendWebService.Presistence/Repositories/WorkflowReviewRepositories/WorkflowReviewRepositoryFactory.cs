
using Application.Contracts.Persistences;
using Application.Model.EAVEngine;
using Persistence.Data;
using Persistence.Repositories.Organizations;

namespace Persistence.Repositories.WorkflowReviewRepositories
{
    public class WorkflowReviewRepositoryFactory<TCase, TCycle> : IWorkflowReviewRepositoryFactory<TCase, TCycle>
    {

        // DbContext instance
        protected readonly ApplicationDbContext _context;
        protected readonly IGetObjectType _getObjectType;
        public string _name;

        public WorkflowReviewRepositoryFactory(ApplicationDbContext context, string ObjectType)
        {
            _context = context;
            switch (ObjectType)
            {
                case "PreDocuments":
                    _getObjectType = new PreDocumentRepository(context);
                    break;
                
            }
        }
        public string GetObjectType(int id)
        {
            return _getObjectType.GetObjectType(id);
        }

        int IWorkflowReviewRepositoryFactory<TCase, TCycle>.GetNextModel(TCase workflowCycle, TCycle workflowCase)
        {
            throw new NotImplementedException();
        }

        TakeActionModel IWorkflowReviewRepositoryFactory<TCase, TCycle>.GetObjectModel(int id)
        {
            throw new NotImplementedException();
        }

        string IWorkflowReviewRepositoryFactory<TCase, TCycle>.GetObjectType(int id)
        {
            throw new NotImplementedException();
        }

        int IWorkflowReviewRepositoryFactory<TCase, TCycle>.UpdateObjectModel(TakeActionModel reviewObjectModel, bool finalAction)
        {
            throw new NotImplementedException();
        }
    }
}

