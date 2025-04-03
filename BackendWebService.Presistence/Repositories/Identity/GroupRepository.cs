using Application.Contracts.Persistence.ActorRepositories;

using Persistence.Data;

namespace Persistence.Repositories.Identity
{
    public class GroupRepository : IActorRepository<WAction>
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<WAction> getActions(int userid)
        {
            throw new NotImplementedException();
        }

        public string GetActorType(int id)
        {
            var group = _context.Groups.FirstOrDefault(u => u.Id == id);
            return group is null ? "" : group.Name;
        }
    }
}
