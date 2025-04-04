using Application.Contracts.DTOs;
using Application.DTOs.Permission;

namespace Application.Contracts.Services;

public interface IPermissionService
{
    IResponse<List<string>> GetAll();

    Task<IResponse<PermissionResponse>> GetRolePermissions(int roleId);

    Task<IResponse<int>> AddPermissionsToRole(AddPermissionsToRoleRequest request);

    Task<IResponse<IEnumerable<UserPagesResponse>>> GetUserPages(int id);
}
