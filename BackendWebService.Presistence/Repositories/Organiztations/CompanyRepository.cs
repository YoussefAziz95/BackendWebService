using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories.Organizations
{
    /// <summary>
    /// Repository for performing CRUD operations on supplier entities.
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructs a new instance of the SupplierRepository with the specified application database context.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Company fullEntity)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Add(fullEntity);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    throw;
                }

            }
            return result;
        }

        public bool CheckIdExists(int id)
        {
            return _context.Companies.Any(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            if (!CheckIdExists(id))
                return false;
            var change = _context.Remove(_context.Companies.Find(id));
            _context.SaveChanges();
            return change.State == EntityState.Deleted;
        }

        public IQueryable<GetPaginatedCompany> GetPaginated()
        {
            var companyResponse = from c in _context.Companies
                                  select new GetPaginatedCompany(c.Id, c.Organization.City, c.Organization.Country, c.Organization.StreetAddress, c.Organization.Email, c.Organization.TaxNo, Enum.GetName(typeof(RoleEnum), c.Organization.Type), c.Organization.Name);
            return companyResponse.ToList().AsQueryable();
        }

        public CompanyResponse GetResponse(int id)
        {
            var companyResponse = from c in _context.Companies
                                  join o in _context.Organizations on c.OrganizationId equals o.Id
                                  select new CompanyResponse(c.Id, c.Organization.Name, c.Organization.Country, c.Organization.City, c.Organization.StreetAddress, c.Organization.Email, c.Organization.TaxNo, c.Organization.Phone, c.Organization.ImageUrl, c.Organization.Fax, Enum.GetName(typeof(RoleEnum), c.Organization.Type) ?? "Unknown", c.IsActive ?? false, c.CreatedDate ?? DateTime.UnixEpoch, c.UpdateDate
                                            );
            return companyResponse.FirstOrDefault();
        }

        public int Update(Company entity)
        {
            var id = _context.Companies.Update(entity).Entity.Id;
            _context.SaveChanges();
            return id;
        }
    }
}
