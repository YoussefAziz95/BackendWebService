using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmployeeAssignmentAllResponse(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes) : IConvertibleFromEntity<EmployeeAssignment, EmployeeAssignmentAllResponse>
{
    public static EmployeeAssignmentAllResponse FromEntity(EmployeeAssignment EmployeeAssignment) =>
    new EmployeeAssignmentAllResponse(
    EmployeeAssignment.EmployeeId,
    EmployeeAssignment.JobId,
    EmployeeAssignment.AssignedDate,
    EmployeeAssignment.Status,
    EmployeeAssignment.EmployeeResponseDate,
    EmployeeAssignment.AdminNotes);
}