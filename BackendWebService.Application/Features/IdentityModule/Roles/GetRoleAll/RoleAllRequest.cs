using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record RoleAllRequest(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int? ParentId,
string DisplayName,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<RoleAllResponse>>
{
    public IValidator<RoleAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<RoleAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

