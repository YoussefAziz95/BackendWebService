using Application.Features;
using Application.Features;
using Domain;

namespace Application.Contracts.Persistence;

public interface IRoleRepository
{
    public RoleResponse? getRole(int id);
    public IQueryable<Role> getRoles();
    public List<ClaimResponse> GetRolePermissions(int id);
}
