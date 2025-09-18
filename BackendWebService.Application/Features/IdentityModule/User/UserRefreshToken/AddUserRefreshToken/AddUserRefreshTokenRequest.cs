using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddUserRefreshTokenRequest(
int UserId,
AddUserRequest User,
DateTime CreatedAt,
bool IsValid,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleToEntity<UserRefreshToken>, IRequest<int>
{
    public UserRefreshToken ToEntity() => new UserRefreshToken
    {
        UserId = UserId,
        User = User.ToEntity(),
        CreatedAt = CreatedAt,
        IsValid = IsValid,
        OrganizationId = OrganizationId,
        IsActive = IsActive,
        IsDeleted = IsDeleted,
        IsSystem = IsSystem,
        CreatedDate = CreatedDate,
        CreatedBy = CreatedBy,
        UpdatedDate = UpdatedDate,
        UpdatedBy = UpdatedBy

    };
}