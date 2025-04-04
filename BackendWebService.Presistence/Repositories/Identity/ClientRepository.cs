using Application.Contracts.Persistences;
using Application.Model.Notifications;
using Microsoft.AspNetCore.Http;
using Persistence.Data;


namespace Persistence.Repositories.Identity
{
    public class ClientRepository : IClientRepository
    {
        private static ApplicationDbContext _context;
        public UserInfo _userInfo { get; set; }

        public ClientRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            if (_context is not null)
            {
                getUser(httpContextAccessor.HttpContext.User.Identity.Name);
                IClientRepository._users = GetUsers().ToList();
            }
        }
        public static ApplicationDbContext Context
        {
            get
            {
                if (Context is null)
                    throw new InvalidOperationException();
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        private void getUser(string? userName)
        {
            if (userName is not null)
                _userInfo = GetUsers().FirstOrDefault(u => u.Username == userName);
        }
        public static UserInfo getUser(int id)
        {
            return GetUsers().FirstOrDefault(u => u.UserId == _context.userInfo.UserId);
        }
        private static IQueryable<UserInfo> GetUsers()
        {

            var users = from u in _context.Users
                        join o in _context.Organizations on u.OrganizationId equals o.Id
                        join c in _context.Companies on o.Id equals c.OrganizationId into companies
                        from c in companies.DefaultIfEmpty()
                        join v in _context.Suppliers on o.Id equals v.OrganizationId into suppliers
                        from v in suppliers.DefaultIfEmpty()
                        join cv in _context.SupplierAccounts on v.Id equals cv.SupplierId into companySuppliers
                        from cv in companySuppliers.DefaultIfEmpty()
                        join ug in _context.UserGroups on u.Id equals ug.UserId into userGroups
                        from ug in userGroups.DefaultIfEmpty()
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        select new UserInfo
                        {
                            ConnectionId = u.Id.ToString(),
                            Username = u.UserName,
                            UserId = u.Id,
                            GroupId = ug.GroupId,
                            RoleId = ur.RoleId,
                            OrganizationId = o.Id,
                            CompanyId = c.Id,
                            SupplierId = v.Id,
                            RoleParentId = ur.RoleId,
                            SupplierAccountId = cv.Id
                        };
            return users;
        }

    }
}
