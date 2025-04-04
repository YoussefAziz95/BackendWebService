using Application.Contracts.Persistences;
using Application.DTOs.Suppliers;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Persistence.Repositories.Organizations
{
    /// <summary>
    /// Repository for performing CRUD operations on supplier entities.
    /// </summary>
    public class SupplierRepository : ISupplierRepository, IGetObjectType
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructs a new instance of the SupplierRepository with the specified application database context.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// 

        public SupplierRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<int> Register(int supplierId)
        {
            SupplierAccount companySupplier = new SupplierAccount()
            {
                OrganizationId = _context.Suppliers.Where(v => v.Id == supplierId).Select(v => v.OrganizationId).First(),
                CompanyId = _context.userInfo.CompanyId ?? 0,
                SupplierId = supplierId
            };
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    companySupplier.IsApproved = true;
                    await _context.AddAsync(companySupplier);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    throw;
                }
            }
            return companySupplier.Id;
        }
        public async Task<int> AddAsync(Supplier supplier, User user, string generateRandomPassword)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Organization organization = supplier.Organization;
                    organization.FaxNo = organization.Fax;
                    organization.Type = OrganizationEnum.Supplier;
                    var x = _context.Add(organization);
                    _context.SaveChanges();



                    _context.Update(organization);
                    _context.AddRange(organization.Name);


                    supplier.OrganizationId = organization.Id;
                    _context.Add(supplier);
                    _context.SaveChanges();
                    await _userManager.UpdateSecurityStampAsync(user);
                    user = await GetSupplierUser(user, supplier, generateRandomPassword);
                    _context.Add(user);
                    _context.SaveChanges();
                    var result = await _userManager.AddToRoleAsync(user, RoleEnum.Technician.ToString());
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
            return supplier.Id;
        }

        private async Task<User> GetSupplierUser(User user, Supplier supplier, string generateRandomPassword)
        {
            user.UserName = supplier.Organization.Email.Split('@').First();
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, generateRandomPassword);
            user.UserName = user.Email.Split('@').First();
            user.OrganizationId = supplier.OrganizationId;
            user.OrganizationId = supplier.OrganizationId;
            user.SecurityStamp = await _userManager.GetSecurityStampAsync(user);
            return user;
        }

        public bool CheckIdExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Supplier GetById(int id)
        {
            var supplier = GetSupplierById(id);

            return supplier;
        }
        private Supplier GetSupplierById(int id)
        {
            return _context.Suppliers
                .Where(b => b.Id == id)
                .Include(c => c.Organization).Include(c => c.SupplierCategories).AsNoTracking().First();
        }
        public string GetObjectType(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetPaginatedSupplier> GetPaginated(int CompanyId)
        {

            var company = _context.Companies.Where(c => c.Id == CompanyId).First();
            if (company is null)
                return new List<GetPaginatedSupplier>();

            var result = from v in _context.Suppliers
                         join cv in _context.SupplierAccounts on v.Id equals cv.SupplierId into cvs
                         from cv in cvs.DefaultIfEmpty()
                         join o in _context.Organizations on v.OrganizationId equals o.Id
                         where cv.CompanyId == company.Id || cv.CompanyId == null
                         select new GetPaginatedSupplier
                         {
                             Id = v.Id,
                             SupplierAccountId = cv.Id,
                             Email = o.Email,
                             TaxNo = o.TaxNo,
                             Name = o.Name,
                             Country = o.Country,
                             StreetAddress = o.StreetAddress,
                             City = o.City,
                         };

            return result?.ToList() ?? new List<GetPaginatedSupplier>();
        }

        public int Update(Supplier entity)
        {
            Supplier supplier = GetById(entity.Id);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    supplier.Organization.FaxNo = entity.Organization.Fax;
                    supplier.Organization.Email = entity.Organization.Email;
                    supplier.Organization.Phone = entity.Organization.Phone;
                    supplier.Organization.TaxNo = entity.Organization.TaxNo;

                    supplier.Organization.Country = entity.Organization.Country;
                    supplier.Organization.StreetAddress = entity.Organization.StreetAddress;
                    supplier.Organization.City = entity.Organization.City;


                    _context.Suppliers.Update(supplier);

                    _context.SaveChanges();
                    var existingCategories = _context.SupplierCategories
                         .Where(vc => vc.SupplierId == supplier.Id)
                         .ToList();

                    var newCategories = entity.SupplierCategories;


                    var categoriesToAdd = newCategories
                        .Where(newCat => !existingCategories.Any(oldCat => oldCat.CategoryId == newCat.CategoryId))
                        .ToList();


                    var categoriesToDelete = existingCategories
                        .Where(oldCat => !newCategories.Any(newCat => newCat.CategoryId == oldCat.CategoryId))
                        .ToList();


                    categoriesToAdd.ForEach(category => category.SupplierId = supplier.Id);
                    _context.AddRange(categoriesToAdd);


                    _context.SupplierCategories.RemoveRange(categoriesToDelete);

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
            return supplier.Id;
        }

        public List<GetPaginatedSupplier> GetRegisteredSupplier()
        {
            throw new NotImplementedException();
        }
    }
}
