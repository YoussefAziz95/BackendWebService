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

        public IQueryable<CompanyAllResponse> GetPaginated()
        {

            //var companyResponse = from c in _context.Companies
            //                      join a in _context.Set<Address>() on c.OrganizationId equals a.OrganizationId into ca
            //                      from a in ca.DefaultIfEmpty()
            //                      join co in _context.Set<Contact>() on c.OrganizationId equals co.OrganizationId into cco
            //                      from co in cco.DefaultIfEmpty()
            //                      join cc in _context.Set<CompanyCategory>() on c.OrganizationId equals cc.OrganizationId into ccc
            //                      from cc in ccc.DefaultIfEmpty()
            //                      join m in _context.Set<Manager>() on c.OrganizationId equals m.OrganizationId into cm
            //                      from m in cm.DefaultIfEmpty()
            //                      select new CompanyAllResponse(c.Id, c.CompanyName, c..Country, c.Organization.StreetAddress, c.Organization.Email, c.Organization.TaxNo, Enum.GetName(typeof(RoleEnum), c.Organization.Type), c.Organization.Name);
            var companyResponse = new List<CompanyAllResponse>();
            return companyResponse.ToList().AsQueryable();
        }

        public CompanyResponse GetResponse(int id)
        {

            throw new NotImplementedException();
            //var companyResponse = from c in _context.Companies
            //                      join o in _context.Organizations on c.OrganizationId equals o.Id
            //                      select new CompanyResponse(
            //                                c.Id,
            //                                c.Organization.Name,
            //                                c.Organization.Country,
            //                                c.Organization.City,
            //                                c.Organization.StreetAddress,
            //                                c.Organization.Email,
            //                                c.Organization.TaxNo,
            //                                c.Organization.Phone,
            //                                c.Organization.FileId!,
            //                                null,
            //                                c.Organization.FaxNo,
            //                                Enum.GetName(typeof(RoleEnum),
            //                                c.Organization.Type) ?? "Unknown",
            //                                c.IsActive ?? false,
            //                                c.CreatedDate ?? DateTime.UnixEpoch,
            //                                c.UpdatedDate,
            //                                c.Organization.Addresses.Select(a => new AddressResponse(a.Id, a.IsAdministration, a.FullAddress, a.Street, a.Zone, a.Street, a.City)).ToList(),
            //                                c.Organization.Contacts.Select(c => new ContactResponse(c.Id, c.Type, c.Value)).ToList());
            //return companyResponse.FirstOrDefault();
        }

        public int Update(Company entity)
        {
            var id = _context.Companies.Update(entity).Entity.Id;
            _context.SaveChanges();
            return id;
        }
    }
}
