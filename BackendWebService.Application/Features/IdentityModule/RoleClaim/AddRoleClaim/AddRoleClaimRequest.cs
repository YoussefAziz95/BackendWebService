using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddRoleClaimRequest(
string? ClaimType,
string? ClaimValue,
DateTime? CreatedDate,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleToEntity<RoleClaim>, IRequest<int>
{
    public RoleClaim ToEntity() => new RoleClaim
    {
        ClaimType = ClaimType,
        ClaimValue = ClaimValue,
        CreatedDate = CreatedDate,
        OrganizationId = OrganizationId,
        IsActive = IsActive,
        IsDeleted = IsDeleted,
        IsSystem = IsSystem,
        CreatedBy = CreatedBy,
        UpdatedDate = UpdatedDate,
        UpdatedBy = UpdatedBy,
    };
}