using Domain.Enums;

namespace Application.Features;
public record UpdateEmployeeAssignmentRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes);