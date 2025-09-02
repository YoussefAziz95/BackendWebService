using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record EmployeeCertificationResponse(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes):IConvertibleFromEntity<EmployeeCertification, EmployeeCertificationResponse>
{
public static EmployeeCertificationResponse FromEntity(EmployeeCertification EmployeeCertification) =>
new EmployeeCertificationResponse(
EmployeeCertification.EmployeeId,
EmployeeCertification.CertificationName,
EmployeeCertification.IssuingAuthority,
EmployeeCertification.IssuedDate,
EmployeeCertification.ExpirationDate,
EmployeeCertification.Status,
EmployeeCertification.VerificationNotes);
}