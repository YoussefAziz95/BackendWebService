using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmployeeJobAllResponse(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes) : IConvertibleFromEntity<EmployeeJob, EmployeeJobAllResponse>
{
    public static EmployeeJobAllResponse FromEntity(EmployeeJob EmployeeJob) =>
    new EmployeeJobAllResponse(
    EmployeeJob.EmployeeId,
    EmployeeJob.JobId,
    EmployeeJob.AssignedDate,
    EmployeeJob.Status,
    EmployeeJob.CompletionDate,
    EmployeeJob.Notes);
}