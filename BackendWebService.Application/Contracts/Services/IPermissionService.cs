using Application.Contracts.Features;
using Application.Features;
namespace Application.Contracts.Services;

public interface IPermissionService
{
    IResponse<List<string>> GetAll();

    Task<IResponse<PermissionResponse>> GetRolePermissions(int roleId);

    Task<IResponse<int>> AddPermissionsToRole(AddPermissionsToRoleRequest request);

    Task<IEnumerable<UserPagesResponse>> GetUserPages(int id);
}
