using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchEmployeeAllRequest(
int BranchId,
int UserId,
string? JobTitle,
bool IsActive,
DateTime AssignedAt,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<BranchEmployeeAllResponse>>
{
    public IValidator<BranchEmployeeAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchEmployeeAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

