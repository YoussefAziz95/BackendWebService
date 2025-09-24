using Application.Contracts.Features;
using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddJobRequest(
string Name,
string? Description,
DateTime StartDate,
DateTime EndDate,
DateTime? ExpirationTime,
bool IsVerified,
List<AddEmployeeAssignmentRequest> EmployeeAssignments) : IConvertibleToEntity<Job>, IRequest<int>
{
    public Job ToEntity() => new Job
    {
        Name = Name,
        Description = Description,
        StartDate = StartDate,
        EndDate = EndDate,
        ExpirationTime = ExpirationTime,
        IsVerified = IsVerified,
        EmployeeAssignments = EmployeeAssignments.Select(x => x.ToEntity()).ToList()
    };
}