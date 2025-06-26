using Application.Contracts.Persistence;
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

        public int GetNextModel(TCase workflowCycle, TCycle wcase)
        {
            throw new NotImplementedException();
        }

        public WorkflowReviewObjectModel GetObjectModel(int id)
        {
            throw new NotImplementedException();
        }


        public int UpdateObjectModel(TakeActionModel reviewObjectModel, bool finalAction)
        {
            throw new NotImplementedException();
        }
    }
}

