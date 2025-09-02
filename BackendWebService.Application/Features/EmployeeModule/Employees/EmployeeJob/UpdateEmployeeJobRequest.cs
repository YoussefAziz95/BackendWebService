using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record UpdateEmployeeJobRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes):IConvertibleToEntity<EmployeeJob>
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