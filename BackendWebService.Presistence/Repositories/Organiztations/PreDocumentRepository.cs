using Application.Contracts.Persistence.WorkflowReviewRepositories;
using Persistence.Data;

namespace Persistence.Repositories.Organizations
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
