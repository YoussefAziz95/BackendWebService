using Application.Contracts.Presistence.Identities;
using Application.Model.Notifications;
using Persistence.Data;


namespace Persistence.Repositories.Identity
{
    public class ClientRepository : IClientRepository
    {
        private static ApplicationDbContext _context;
        public UserInfo _userInfo { get; set; }

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
            if(_context is not null)
            {
                IClientRepository._users = GetUsers().ToList();
                IClientRepository._userInfo = getUser();
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
        private  UserInfo getUser()
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
