using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserLoginAllRequest(
int? OrganizationId,
DateTime LoggedOn,
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
string? SortBy = "asc") : IRequest<List<UserLoginAllResponse>>
{
    public IValidator<UserLoginAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserLoginAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

