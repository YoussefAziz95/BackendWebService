using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserRoleAllRequest(
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
string? SortBy = "asc") : IRequest<List<UserRoleAllResponse>>
{
    public IValidator<UserRoleAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserRoleAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

