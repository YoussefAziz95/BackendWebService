using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateUserClaimRequest(
string? ClaimType, 
string? ClaimValue,
int UserId,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleToEntity<UserClaim>, IRequest<int>
{
    public UserClaim ToEntity() => new UserClaim
    {
        ClaimType=ClaimType,
        ClaimValue=ClaimValue,
        UserId= UserId,
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