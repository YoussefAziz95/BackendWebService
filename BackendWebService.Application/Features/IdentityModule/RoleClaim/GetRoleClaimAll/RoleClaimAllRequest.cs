using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record RoleClaimAllRequest(
string? ClaimType,
string? ClaimValue,
DateTime? CreatedDate,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<RoleClaimAllResponse>>, IRequest<int>
{
    public IValidator<RoleClaimAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<RoleClaimAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

