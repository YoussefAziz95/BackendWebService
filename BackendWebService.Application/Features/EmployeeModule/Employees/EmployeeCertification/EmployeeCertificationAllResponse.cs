using Domain.Enums;

namespace Application.Features;
public record EmployeeCertificationAllResponse(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes);