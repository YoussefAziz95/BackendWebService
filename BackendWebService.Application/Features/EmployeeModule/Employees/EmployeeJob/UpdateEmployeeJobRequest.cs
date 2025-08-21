using Domain.Enums;

namespace Application.Features;
public record UpdateEmployeeJobRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes);