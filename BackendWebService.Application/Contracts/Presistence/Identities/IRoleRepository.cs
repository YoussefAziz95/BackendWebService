using Application.DTOs.Permission;
using Application.DTOs.Role;


namespace Application.Contracts.Presistence.Identities
{
    public interface IRoleRepository
    {
        public RoleResponse? getRole(int id);
        public IQueryable<Role> getRoles();
        public List<ClaimResponse> GetRolePermissions(int id);
    }
}
