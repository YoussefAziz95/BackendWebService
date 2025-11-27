using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Persistence.Data;
using System.Data;

namespace Persistence.Repositories.Identity
{
    public class RoleRepository : IActorRepository<ActionActor>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ActionActor> getActions(int userid)
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
                .Select(c => new ClaimResponse(c.Id, c.ClaimValue)).ToList();
            return roleResponse;
        }

        public RoleResponse? getRole(int id)
        {

            throw new NotImplementedException();
            //var query = from r in _context.Roles
            //            join rc in _context.RoleClaims on r.Id equals rc.RoleId into rcs
            //            where r.Id == id
            //            select new RoleResponse(r.Id, r.Name, rcs.Select(rc => new ClaimResponse(rc.Id, rc.ClaimValue)).ToList());
            //return query.FirstOrDefault();
        }
    }
}
