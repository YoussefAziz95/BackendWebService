

namespace Application.Contracts.Presistence.Identities
{
    public interface IUserRepository
    {
        public IQueryable<User> getUsers();
        User? getById(int id);
    }
}
