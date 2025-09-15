using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddEmployeeJobRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes) : IConvertibleToEntity<EmployeeJob>,IRequest<int>
{
    public EmployeeJob ToEntity() => new EmployeeJob
    {
        EmployeeId = EmployeeId,
        JobId = JobId,
        AssignedDate = AssignedDate,
        Status = Status,
        CompletionDate = CompletionDate,
        Notes = Notes
    };
}