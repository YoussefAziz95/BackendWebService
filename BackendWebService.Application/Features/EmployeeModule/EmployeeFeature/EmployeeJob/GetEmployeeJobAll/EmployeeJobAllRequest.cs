using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeJobAllRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmployeeJobAllResponse>>
{
    public IValidator<EmployeeJobAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeJobAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

