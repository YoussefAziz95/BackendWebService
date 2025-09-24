using Application.Profiles;
using Domain;

namespace Application.Features;
public record JobResponse(
string Name,
string? Description,
DateTime StartDate,
DateTime EndDate,
DateTime? ExpirationTime,
bool IsVerified,
List<EmployeeAssignmentResponse> EmployeeAssignments) : IConvertibleFromEntity<Job, JobResponse>
{
    public static JobResponse FromEntity(Job Job) =>
    new JobResponse(
    Job.Name,
    Job.Description,
    Job.StartDate,
    Job.EndDate,
    Job.ExpirationTime,
    Job.IsVerified,
    Job.EmployeeAssignments.Select(EmployeeAssignmentResponse.FromEntity).ToList());
}