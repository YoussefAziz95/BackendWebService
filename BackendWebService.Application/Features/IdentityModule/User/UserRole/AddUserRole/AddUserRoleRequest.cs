using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddUserRoleRequest(
AddUserRequest User,
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
        User = User.ToEntity(),
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