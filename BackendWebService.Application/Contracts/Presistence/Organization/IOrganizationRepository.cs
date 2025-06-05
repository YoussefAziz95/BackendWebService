namespace Application.Contracts.Persistence;

public interface IOrganizationRepository<TEntity, TResponse, TResponses>
{
    int Add(TEntity entity);
    int Update(TEntity entity);
    bool Delete(int id);
    TResponse GetResponse(int id);
    IQueryable<TResponses> GetPaginated();
    bool CheckIdExists(int id);
}
