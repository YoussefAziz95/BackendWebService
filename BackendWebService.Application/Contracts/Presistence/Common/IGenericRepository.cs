using Application.Features.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence;

public interface IGenericRepository<T>
{
    IQueryable<T> GetAllAsQuerable(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null!, bool disabledTracking = true, bool isActive = true, bool isDeleted = false);
    IEnumerable<T> GetAll(
                Expression<Func<T, bool>> filter = null!,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null!,
                bool disabledTracking = true, bool isActive = true, bool isDeleted = false);
    Dictionary<int, string> GetDropdownOptionsList(string[] columnNames);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter = null!,
                   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null!,
                   bool disableTracking = true, bool isActive = true, bool isDeleted = false);
    T Get(Expression<Func<T, bool>> filter = null!,
                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null!,
                  bool disableTracking = true, bool isActive = true, bool isDeleted = false);

    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    T Update(int id, T updatedEntity);
    bool UpdateRangeFromEntity(IEnumerable<T> oldEntities, IEnumerable<T> newEntities);
    void UpdateRange(IEnumerable<T> oldEntities, IEnumerable<T> newEntities);
    void Delete(T entity);
    void SoftDelete(T entity);
    void Activate(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task DeleteRangeByAsync(Expression<Func<T, bool>> filter);
    T GetById(int id);
    Task<T?> GetByIdAsync(int id);
    public bool Exists(Expression<Func<T, bool>> filter = null!);
    public int ExecuteSql(string query, params object[] args);
    bool ExistsNoTracking(Expression<Func<T, bool>> filter = null!);
}
