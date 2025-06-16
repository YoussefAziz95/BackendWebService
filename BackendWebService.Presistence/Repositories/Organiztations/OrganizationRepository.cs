using Application.Contracts.Persistence;
using Domain;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Persistence.Repositories.Organizations
{
    public abstract class OrganizationRepository<TEntity, TResponse, TResponses>
       : IOrganizationRepository<TEntity, TResponse, TResponses>
    {
        public ApplicationDbContext _context { get; set; }
        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public abstract int Add(TEntity entity);
        protected int AddOrganization(Organization entity)
        {
            entity.FaxNo = entity.FaxNo;
            _context.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public abstract bool Delete(int id);
        protected bool DeleteOrganization(int id)
        {
            var entity = _context.Set<Organization>().Find(id);
            _context.Organizations.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public abstract TResponse GetResponse(int id);
        public abstract Supplier GetById(int id);
        protected Organization GetOrganization(int id)
        {
            var organization = _context.Organizations.Find(id);
            return organization ?? new Organization();
        }
        public abstract int Update(TEntity entity);
        protected int UpdateOrganization(Organization entity)
        {
            var organization = _context.Set<Organization>().AsNoTracking().First(o => o.Id == entity.Id);

            if (organization == null) return -1;

            _context.Update(organization);

            _context.SaveChanges();
            return entity.Id;
        }
        public abstract IQueryable<TResponses> GetPaginated();

        public abstract bool CheckIdExists(int id);

        protected bool CheckOrganizationIdExists(int id)
        {
            return _context.Set<Organization>().AsNoTracking().Any(e => EF.Property<int>(e, "Id") == id);
        }
    }
}
