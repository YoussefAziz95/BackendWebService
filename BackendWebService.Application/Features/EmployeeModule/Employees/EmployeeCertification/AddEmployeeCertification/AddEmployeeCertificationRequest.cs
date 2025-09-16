using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddEmployeeCertificationRequest(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes) : IConvertibleToEntity<EmployeeCertification>,IRequest<int>
{
    public EmployeeCertification ToEntity() => new EmployeeCertification
    {
        EmployeeId = EmployeeId,
        CertificationName = CertificationName,
        IssuingAuthority = IssuingAuthority,
        IssuedDate = IssuedDate,
        ExpirationDate = ExpirationDate,
        Status = Status,
        VerificationNotes = VerificationNotes
    };
}