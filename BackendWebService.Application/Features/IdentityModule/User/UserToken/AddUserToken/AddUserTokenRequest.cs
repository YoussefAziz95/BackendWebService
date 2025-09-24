using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddUserTokenRequest(
AddUserRequest User,
DateTime GeneratedTime,
int Id,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleToEntity<UserToken>, IRequest<int>
{
    public UserToken ToEntity() => new UserToken
    {
        User = User.ToEntity(),
        GeneratedTime = GeneratedTime,
        Id = Id,
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