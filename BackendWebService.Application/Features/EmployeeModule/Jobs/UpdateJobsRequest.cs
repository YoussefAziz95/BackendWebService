using Domain;

namespace Application.Features;
public record UpdateJobRequest(
string Name,
 string? Description,
 DateTime StartDate,
 DateTime EndDate,
 DateTime? ExpirationTime,
 bool IsVerified,
 List<UpdateEmployeeAssignmentRequest> EmployeeAssignments);