using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Roles;

namespace Application.Contracts.Services;

public interface IApplicationRoleService
{
    Task<IResponse<int>> AddRoleAsync(CreateRoleRequest request);
    Task<IResponse<string>> AddRoleToUserAsync(AddRoleToUserRequest request);
    Task<PaginatedResponse<RolesResponse>> GetRolesPaginated(GetPaginatedRequest request);
    Task<IResponse<RoleResponse>> GetRoleAsync(int id);
    Task<IResponse<int>> UpdateRoleAsync(int id, UpdateRoleRequest request);
    Task<IResponse<string>> DeleteRoleAsync(int id);
    bool CheckIdExists(int id);
}
