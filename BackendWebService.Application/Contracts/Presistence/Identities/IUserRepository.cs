using Domain;

namespace Application.Contracts.Persistence;

public interface IUserRepository
{
    public IQueryable<User> getUsers();
    User? getById(int id);
}
