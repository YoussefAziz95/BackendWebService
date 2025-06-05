using Application.Contracts.Persistence;
using Application.Features.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Persistence.Repositories.Common
{
    /// <summary>
    /// Generic repository for performing CRUD operations on entities of type T.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // DbContext instance
        protected readonly ApplicationDbContext _context;
        // DbSet for the entity type
        internal DbSet<T> _dbSet;
        private PropertyInfo _propertyId;
        private PropertyInfo[] _propertyInfos;
        private PropertyInfo _OrganizationIdProperty;

        /// <summary>
        /// Constructs the generic repository with the specified application database context.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            var type = typeof(T);
            _propertyInfos = typeof(T).GetProperties();
            _propertyId = type.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            _OrganizationIdProperty = type.GetProperty("OrganizationId");

        }

        public void Add(T entity)
        {
            if (_context.userInfo is not null)
                _OrganizationIdProperty.SetValue(entity, _context.userInfo.OrganizationId);
            _context.Add(entity);
        }

        public async virtual Task AddAsync(T entity)
        {
            if (_context.userInfo is not null)
                _OrganizationIdProperty.SetValue(entity, _context.userInfo.OrganizationId);
            await _context.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _OrganizationIdProperty.SetValue(entity, _context.userInfo.OrganizationId);
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public async Task DeleteRangeByAsync(Expression<Func<T, bool>> filter)
        {
            await _dbSet.Where(filter).ExecuteDeleteAsync();
        }

        public T Get(Expression<Func<T, bool>> filter = null!, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null!, bool disableTracking = true, bool isActive = true, bool isDeleted = false)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (filter is not null) query = query.Where(filter);
            if (include is not null) query = include(query);
            //foreach (PropertyInfo pInfo in _propertyInfos)
            //{
            //    if (pInfo.Name == "IsDeleted")
            //        query = query.ToList().Where(x => x.GetType().GetProperty(pInfo.Name)!.GetValue(x)!.Equals(isDeleted)).AsQueryable();
            //    if (pInfo.Name == "IsActive")
            //        query = query.ToList().Where(x => x.GetType().GetProperty(pInfo.Name)!.GetValue(x)!.Equals(isActive)).AsQueryable();
            //}
            return query.FirstOrDefault()!;


        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null!, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null!, bool disabledTracking = true, bool isActive = true, bool isDeleted = false)
        {
            IQueryable<T> query = _dbSet;
            if (disabledTracking) query = query.AsNoTracking();
            if (filter is not null) query = query.Where(filter);
            if (include is not null) query = include(query);
            //foreach (PropertyInfo pInfo in _propertyInfos)
            //{
            //    if (pInfo.Name == "IsDeleted")
            //        query = query.ToList().Where(x => x.GetType().GetProperty(pInfo.Name)!.GetValue(x)!.Equals(isDeleted)).AsQueryable();
            //    if (pInfo.Name == "IsActive")
            //        query = query.ToList().Where(x => x.GetType().GetProperty(pInfo.Name)!.GetValue(x)!.Equals(isActive)).AsQueryable();
            //}
            if (orderBy is not null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }



        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter = null!, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null!, bool disableTracking = true, bool isActive = true, bool isDeleted = false)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (filter is not null) query = query.Where(filter);
            if (include is not null) query = include(query);
            //foreach (PropertyInfo pInfo in _propertyInfos)
            //{
            //    if (pInfo.Name == "IsDeleted")
            //        query = query.ToList().Where(x => x.GetType().GetProperty(pInfo.Name)!.GetValue(x)!.Equals(false)).AsQueryable();
            //    if (pInfo.Name == "IsActive")
            //        query = query.ToList().Where(x => x.GetType().GetProperty(pInfo.Name)!.GetValue(x)!.Equals(true)).AsQueryable();
            //}
            return await query.FirstOrDefaultAsync()!;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public bool Exists(Expression<Func<T, bool>> filter = null!)
        {
            return _dbSet.Any(filter);
        }

        public void SoftDelete(T entity)
        {
            foreach (PropertyInfo pInfo in _propertyInfos)
            {
                if (pInfo.Name == "DeletedDate" && pInfo.CanWrite) pInfo.SetValue(entity, DateTime.UtcNow);
                if (pInfo.Name == "IsActive" && pInfo.CanWrite) pInfo.SetValue(entity, false);
                if (pInfo.Name == "IsDeleted" && pInfo.CanWrite) pInfo.SetValue(entity, true);
            }
            _dbSet.Update(entity);
        }
        public void Activate(T entity)
        {
            foreach (PropertyInfo pInfo in _propertyInfos)
            {
                if (pInfo.Name == "DeletedDate" && pInfo.CanWrite) pInfo.SetValue(entity, DateTime.UtcNow);
                if (pInfo.Name == "IsActive" && pInfo.CanWrite) pInfo.SetValue(entity, true);
                if (pInfo.Name == "IsDeleted" && pInfo.CanWrite) pInfo.SetValue(entity, false);
            }
            _dbSet.Update(entity);
        }
        public virtual T Update(int id, T updatedEntity)
        {
            T entity = GetById(id);
            UpdateEntityFromDto(entity, updatedEntity);
            _dbSet.Update(entity);
            return entity;
        }
        public bool UpdateRangeFromEntity(IEnumerable<T> oldEntities, IEnumerable<T> newEntities)
        {
            foreach (T _new in newEntities)
            {
                var _newId = (int)_new.GetType().GetProperty(_propertyId.Name)!.GetValue(_new)!;
                var old = oldEntities.Where(
                    o => ((int)o.GetType().GetProperty(_propertyId.Name)!.GetValue(o)!).Equals(_newId)).ToList().FirstOrDefault();
                if (old is null)
                {
                    _propertyId.SetValue(_new, null);
                    _dbSet.Add(_new);
                    _context.SaveChanges();
                }
                else
                {
                    oldEntities = oldEntities.Where(o => !((int)o.GetType().GetProperty(_propertyId.Name)!.GetValue(o)!).Equals(_newId)).ToList();
                    UpdateEntityFromDto(old, _new);
                    _dbSet.Update(old);
                    _context.SaveChanges();
                }

            }
            foreach (T o in oldEntities) _dbSet.Remove(o);
            var result = _context.SaveChanges();
            return result > 0 ? true : false;
        }
        public void UpdateRange(IEnumerable<T> oldEntities, IEnumerable<T> newEntities)
        {
            foreach (T _new in newEntities)
            {
                var _newId = (int)_new.GetType().GetProperty(_propertyId.Name)!.GetValue(_new)!;
                var old = oldEntities.Where(
                    o => ((int)o.GetType().GetProperty(_propertyId.Name)!.GetValue(o)!).Equals(_newId)).ToList().FirstOrDefault();
                if (old is null)
                {
                    _propertyId.SetValue(_new, null);
                    _dbSet.Add(_new);
                }
                else
                {
                    oldEntities = oldEntities.Where(o => !((int)o.GetType().GetProperty(_propertyId.Name)!.GetValue(o)!).Equals(_newId)).ToList();
                    UpdateEntityFromDto(old, _new);
                    _dbSet.Update(old);
                }

            }
            foreach (T o in oldEntities) _dbSet.Remove(o);
        }
        protected void UpdateEntityFromDto(T entity, T updatedDto)
        {
            var entityType = typeof(T);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedDto);
                var defaultValue = property.PropertyType.IsValueType ? Activator.CreateInstance(property.PropertyType) : null;

                if (updatedValue != null && !updatedValue.Equals(defaultValue) && (!property.PropertyType.Name.Contains("List") || property.Name == "Id"))
                {
                    property.SetValue(entity, updatedValue);
                }
            }
        }

        public int ExecuteSql(string query, params object[] args)
        {
            return _context.Database.ExecuteSqlRaw(query, args);
        }
        
       


        public bool ExistsNoTracking(Expression<Func<T, bool>> filter = null!)
        {
            return _dbSet.AsNoTracking().Any(filter);
        }

        public Dictionary<int, string> GetDropdownOptionsList(string[] columnNames)
        {

            List<PropertyInfo> properties = new List<PropertyInfo>();
            var entityType = typeof(T);
            var idProperty = _propertyId;
            foreach (string columnName in columnNames)
            {
                var columnProperty = entityType.GetProperty(columnName);
                if (columnProperty is null)
                {
                    throw new ArgumentException($"GenericRepository.GetDropdownOptions() : Column '{columnName}' not found in type '{typeof(IEntity).Name}'.");
                }
                properties.Add(columnProperty);
            }
            var columnValues = _dbSet.ToList()
            .Select(e => new
            {
                Key = idProperty is null ? 0 : (int)idProperty.GetValue(e)!,
                Value = properties.Select(p => p.GetValue(e)?.ToString() ?? string.Empty).First()
            }).ToDictionary(x => x.Key, x => x.Value);
            return columnValues;
        }
    }
}
