using Domain.Enums;

namespace Application.Features;
public record AddEmployeeAssignmentRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes);