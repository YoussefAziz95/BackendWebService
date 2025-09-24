using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeAccountAllRequest(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmployeeAccountAllResponse>>
{
    public IValidator<EmployeeAccountAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeAccountAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

