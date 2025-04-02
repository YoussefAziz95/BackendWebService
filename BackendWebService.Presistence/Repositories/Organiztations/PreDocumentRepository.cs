using Application.Contracts.Presistence.WorkflowReviewRepositories;
using Persistence.Data;

namespace Persistence.Repositories.Organiztations
{
    public class PreDocumentRepository : IGetObjectType
    {


        private readonly ApplicationDbContext _context;
        public PreDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetObjectType(int id)
        {
            var doc = _context.PreDocuments.FirstOrDefault(p => p.Id == id);
            return doc is null ? "" : doc.Name;
        }
    }
}
