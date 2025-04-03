using Application.DTOs.Permission;
using Application.DTOs.Roles;
using Domain;
using System.Collections.Generic;
using System.Linq;


namespace Application.Contracts.Persistence.Identities
{
    public interface IRoleRepository
    {
        public RoleResponse? getRole(int id);
        public IQueryable<Role> getRoles();
        public List<ClaimResponse> GetRolePermissions(int id);
    }
}
