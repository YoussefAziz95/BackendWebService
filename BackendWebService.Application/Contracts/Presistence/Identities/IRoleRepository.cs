using Application.DTOs.Roles;
using Domain;


namespace Application.Contracts.Persistences;

public interface IRoleRepository
{
    public RoleResponse? getRole(int id);
    public IQueryable<Role> getRoles();
    public List<ClaimResponse> GetRolePermissions(int id);
}
