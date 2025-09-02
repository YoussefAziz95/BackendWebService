using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddEmployeeAssignmentRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes):IConvertibleToEntity<EmployeeAssignment>
{
public EmployeeAssignment ToEntity() => new EmployeeAssignment
{
EmployeeId = EmployeeId,
JobId = JobId,
AssignedDate = AssignedDate,
Status = Status,
EmployeeResponseDate = EmployeeResponseDate,
AdminNotes = AdminNotes
};
}