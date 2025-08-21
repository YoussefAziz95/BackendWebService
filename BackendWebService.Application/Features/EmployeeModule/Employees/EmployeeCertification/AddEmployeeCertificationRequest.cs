using Domain.Enums;

namespace Application.Features;
public record AddEmployeeCertificationRequest(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes);