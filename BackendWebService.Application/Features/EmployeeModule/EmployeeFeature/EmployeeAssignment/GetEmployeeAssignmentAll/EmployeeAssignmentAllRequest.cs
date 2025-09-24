using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeAssignmentAllRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmployeeAssignmentAllResponse>>
{
    public IValidator<EmployeeAssignmentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeAssignmentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

