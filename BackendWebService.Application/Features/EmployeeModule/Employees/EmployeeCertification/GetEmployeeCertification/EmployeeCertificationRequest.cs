using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeCertificationRequest(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes) : IRequest<EmployeeCertificationResponse>
{
    public IValidator<EmployeeCertificationRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeCertificationRequest> validator)
    {
        throw new NotImplementedException();
    }
}

