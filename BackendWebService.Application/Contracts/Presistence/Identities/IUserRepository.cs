using Domain;

namespace Application.Contracts.Persistences;

public interface IUserRepository
{
    public IQueryable<User> getUsers();
    User? getById(int id);
}
