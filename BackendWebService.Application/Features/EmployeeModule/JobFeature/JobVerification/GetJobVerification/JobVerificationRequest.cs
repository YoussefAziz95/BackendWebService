using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features; 
public record JobVerificationRequest(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified) : IRequest<JobVerificationResponse>
{
    public IValidator<JobVerificationRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<JobVerificationRequest> validator)
    {
        throw new NotImplementedException();
    }
}

