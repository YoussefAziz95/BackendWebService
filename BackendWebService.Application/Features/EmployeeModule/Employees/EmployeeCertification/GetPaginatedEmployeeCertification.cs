using Domain.Enums;

namespace Application.Features;
public record GetPaginatedEmployeeCertification(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes);