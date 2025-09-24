using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeAllRequest(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmployeeAllResponse>>
{
    public IValidator<EmployeeAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

