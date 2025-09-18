using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserClaimAllRequest(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<UserClaimAllResponse>>
{
    public IValidator<UserClaimAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserClaimAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

