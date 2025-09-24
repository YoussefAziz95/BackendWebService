using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserTokenAllRequest(
DateTime GeneratedTime,
int Id,
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
string? SortBy = "asc") : IRequest<List<UserTokenAllResponse>>
{
    public IValidator<UserTokenAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserTokenAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

