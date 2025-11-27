using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserRefreshTokenAllRequest(
int UserId,
DateTime CreatedAt,
bool IsValid,
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
string? SortBy = "asc") : IRequest<List<UserRefreshTokenAllResponse>>
{
    public IValidator<UserRefreshTokenAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserRefreshTokenAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

