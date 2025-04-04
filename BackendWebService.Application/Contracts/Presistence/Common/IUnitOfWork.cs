namespace Application.Contracts.Persistences;

public interface IUnitOfWork
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    int Save();
    Task<int> SaveAsync();
}
