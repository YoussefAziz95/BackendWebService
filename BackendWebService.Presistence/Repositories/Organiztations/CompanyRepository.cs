using Application.Contracts.Persistence.Organizations;
using Application.DTOs.Companies.Response;
using Application.DTOs.Suppliers.Responses;
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
                                  join o in _context.Organizations on c.OrganizationId equals o.Id
                                  select new GetPaginatedCompany
                                  {
                                      Id = c.Id,
                                      City = c.Organization.City,
                                      Country = c.Organization.Country,
                                      StreetAddress = c.Organization.StreetAddress,
                                      Email = c.Organization.Email,
                                      TaxNo = c.Organization.TaxNo,
                                      RoleType = Enum.GetName(typeof(RoleEnum), c.Organization.Type),
                                      Name = o.Name,

                                  };
            return companyResponse.AsQueryable();
        }

        public CompanyResponse GetResponse(int id)
        {
            var companyResponse = from c in _context.Companies
                                  join o in _context.Organizations on c.OrganizationId equals o.Id
                                  select new CompanyResponse
                                  {
                                      Id = c.Id,
                                      City = c.Organization.City,
                                      Country = c.Organization.Country,
                                      StreetAddress = c.Organization.StreetAddress,
                                      Email = c.Organization.Email,
                                      TaxNo = c.Organization.TaxNo,
                                      Fax = c.Organization.Fax,
                                      Phone = c.Organization.Phone,
                                      RoleType = Enum.GetName(typeof(RoleEnum), c.Organization.Type),
                                      Name = c.Organization.Name,
                                      IsActive = c.IsActive,
                                      CreatedDate = c.CreatedDate,
                                      UpdateDate = c.UpdateDate,
                                  };
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
