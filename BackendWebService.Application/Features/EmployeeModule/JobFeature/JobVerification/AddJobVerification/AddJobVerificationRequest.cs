using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddJobVerificationRequest(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified) : IConvertibleToEntity<JobVerification>, IRequest<int>
{
    public JobVerification ToEntity() => new JobVerification
    {
        EmployeeId = EmployeeId,
        Verification = Verification,
        VerificationCode = VerificationCode,
        ExpirationTime = ExpirationTime,
        IsVerified = IsVerified
    };
}