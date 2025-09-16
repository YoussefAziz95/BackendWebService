using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record JobVerificationResponse(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified) : IConvertibleFromEntity<JobVerification, JobVerificationResponse>
{
    public static JobVerificationResponse FromEntity(JobVerification JobVerification) =>
    new JobVerificationResponse(
    JobVerification.EmployeeId,
    JobVerification.Verification,
    JobVerification.VerificationCode,
    JobVerification.ExpirationTime,
    JobVerification.IsVerified);
}