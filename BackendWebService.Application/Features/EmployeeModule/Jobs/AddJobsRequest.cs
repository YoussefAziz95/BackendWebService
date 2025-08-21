using Domain;

namespace Application.Features;
public record AddJobRequest(
 string Name,
 string? Description,
 DateTime StartDate,
 DateTime EndDate,
 DateTime? ExpirationTime,
 bool IsVerified,
 List<AddEmployeeAssignmentRequest> EmployeeAssignments);