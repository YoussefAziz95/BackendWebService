using Application.Model.Notifications;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    int Save();
    Task<int> SaveAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
