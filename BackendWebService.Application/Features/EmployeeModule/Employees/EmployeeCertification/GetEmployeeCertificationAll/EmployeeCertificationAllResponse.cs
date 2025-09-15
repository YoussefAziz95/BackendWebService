using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmployeeCertificationAllResponse(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes) : IConvertibleFromEntity<EmployeeCertification, EmployeeCertificationAllResponse>
{
    public static EmployeeCertificationAllResponse FromEntity(EmployeeCertification EmployeeCertification) =>
    new EmployeeCertificationAllResponse(
    EmployeeCertification.EmployeeId,
    EmployeeCertification.CertificationName,
    EmployeeCertification.IssuingAuthority,
    EmployeeCertification.IssuedDate,
    EmployeeCertification.ExpirationDate,
    EmployeeCertification.Status,
    EmployeeCertification.VerificationNotes);
}