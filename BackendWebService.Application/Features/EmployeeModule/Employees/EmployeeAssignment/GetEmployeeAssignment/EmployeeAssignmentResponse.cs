using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmployeeAssignmentResponse(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes) : IConvertibleFromEntity<EmployeeAssignment, EmployeeAssignmentResponse>
{
    public static EmployeeAssignmentResponse FromEntity(EmployeeAssignment EmployeeAssignment) =>
    new EmployeeAssignmentResponse(
    EmployeeAssignment.EmployeeId,
    EmployeeAssignment.JobId,
    EmployeeAssignment.AssignedDate,
    EmployeeAssignment.Status,
    EmployeeAssignment.EmployeeResponseDate,
    EmployeeAssignment.AdminNotes);
}