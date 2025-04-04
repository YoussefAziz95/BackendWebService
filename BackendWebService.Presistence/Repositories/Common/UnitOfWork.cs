using Application.Contracts.Persistences;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Persistence.Data;

namespace Persistence.Repositories.Common
{
    /// <summary>
    /// Represents a unit of work for managing database transactions.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public AccessEnum Access = AccessEnum.Public;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            if (httpContextAccessor is not null && httpContextAccessor.HttpContext.User.Claims.Count() > 0)
            {
                if (int.TryParse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault()!.Value, out var Id))
                {
                    _context.userInfo.UserId = Id;
                    _context.userInfo.OrganizationId = int.Parse(Contains(httpContextAccessor, "organizationId"));
                    _context.userInfo.CompanyId = int.Parse(Contains(httpContextAccessor, "companyId"));
                    _context.userInfo.SupplierId = int.Parse(Contains(httpContextAccessor, "supplierId"));
                    _context.userInfo.RoleParentId = int.Parse(Contains(httpContextAccessor, "roleParentId"));
                    _context.userInfo.SupplierAccountId = int.Parse(Contains(httpContextAccessor, "companyVendorId"));

                    Access = AccessEnum.Private;
                }
            }

        }
        private string Contains(IHttpContextAccessor httpContextAccessor, string search)
        {
            var flag = httpContextAccessor?.HttpContext?.Request?.Headers.ContainsKey(search) ?? false;
            return flag ? httpContextAccessor.HttpContext.Request.Headers[search] : "0";
        }
        /// <summary>
        /// Releases all resources used by the <see cref="UnitOfWork"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="UnitOfWork"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    try { _context.Dispose(); }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message + "Please Remove this try and catch when you fix email send in company and supplier");
                    }
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Gets the generic repository for a specific entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>An instance of the generic repository for the specified entity type.</returns>
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        /// <summary>
        /// Saves changes made in the unit of work synchronously.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public int Save()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Saves changes made in the unit of work asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing the number of state entries written to the database.</returns>
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
