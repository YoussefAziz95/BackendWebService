using Application.Contracts.Persistence.ActorRepositories;
using Application.Contracts.Persistence.Identities;
using Application.DTOs.Permission;
using Application.DTOs.Roles;
using Domain;
using Persistence.Data;
using System.Data;

namespace Persistence.Repositories.Identity
{
    public class RoleRepository : IActorRepository<WAction>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<WAction> getActions(int userid)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> getRoles()
        {
            var roles = _context.Roles.AsQueryable();
            if (_context.userInfo.OrganizationId > 0)
            {
                roles = roles.Where(c => c.ParentId == _context.userInfo.RoleParentId);
            }
            return roles;
        }
        public string GetActorType(int id)
        {
            var role = _context.Roles.FirstOrDefault(u => u.Id == id);

            return role is null ? "" : role.Name ?? "";
        }

        public List<ClaimResponse> GetRolePermissions(int id)
        {
            var role = _context.Roles.First(r => r.Id == id);
            var roleResponse = _context.RoleClaims.Where(r => r.RoleId == id)
                .Select(c => new ClaimResponse() { Id = c.Id, Value = c.ClaimValue }).ToList();
            return roleResponse;
        }

        public RoleResponse? getRole(int id)
        {
            var query = from r in _context.Roles
                        join rc in _context.RoleClaims on r.Id equals rc.RoleId into rcs
                        where r.Id == id
                        select new RoleResponse
                        {
                            RoleId = r.Id,
                            Claims = rcs.Select(rc => new ClaimResponse() { Id = rc.Id, Value = rc.ClaimValue }).ToList(),
                            Name = r.Name,
                        };
            return query.FirstOrDefault();
        }
    }
}
