using Domain;
using System.Linq;

namespace Application.Contracts.Persistence.Identities
{
    public interface IUserRepository
    {
        public IQueryable<User> getUsers();
        User? getById(int id);
    }
}
