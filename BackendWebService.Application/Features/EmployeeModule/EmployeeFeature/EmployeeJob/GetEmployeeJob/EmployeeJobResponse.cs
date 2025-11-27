using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record EmployeeJobResponse(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes) : IConvertibleFromEntity<EmployeeJob, EmployeeJobResponse>, IRequest<int>
{
    public static EmployeeJobResponse FromEntity(EmployeeJob EmployeeJob) =>
    new EmployeeJobResponse(
    EmployeeJob.EmployeeId,
    EmployeeJob.JobId,
    EmployeeJob.AssignedDate,
    EmployeeJob.Status,
    EmployeeJob.CompletionDate,
    EmployeeJob.Notes);
}