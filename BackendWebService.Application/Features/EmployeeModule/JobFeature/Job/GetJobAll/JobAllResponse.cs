using Application.Profiles;
using Domain;

namespace Application.Features;
public record JobAllResponse(
string Name,
string? Description,
DateTime StartDate,
DateTime EndDate,
DateTime? ExpirationTime,
bool IsVerified) : IConvertibleFromEntity<Job, JobAllResponse>
{
    public static JobAllResponse FromEntity(Job Job) =>
    new JobAllResponse(
    Job.Name,
    Job.Description,
    Job.StartDate,
    Job.EndDate,
    Job.ExpirationTime,
    Job.IsVerified);
}
