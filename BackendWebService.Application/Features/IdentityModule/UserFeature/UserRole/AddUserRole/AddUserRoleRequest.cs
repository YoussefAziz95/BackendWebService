using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddUserRoleRequest(
AddRoleRequest Role,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleToEntity<UserRole>, IRequest<int>
{
    public UserRole ToEntity() => new UserRole
    {
        Role = Role.ToEntity(),
        OrganizationId = OrganizationId,
        IsActive = IsActive,
        IsDeleted = IsDeleted,
        IsSystem = IsSystem,
        CreatedDate = CreatedDate,
        CreatedBy = CreatedBy,
        UpdatedDate = UpdatedDate,
        UpdatedBy = UpdatedBy,
    };
}