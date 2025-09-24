using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features; 
public record JobVerificationAllResponse(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified) : IConvertibleFromEntity<JobVerification, JobVerificationAllResponse>
{
    public static JobVerificationAllResponse FromEntity(JobVerification JobVerification) =>
    new JobVerificationAllResponse(
    JobVerification.EmployeeId,
    JobVerification.Verification,
    JobVerification.VerificationCode,
    JobVerification.ExpirationTime,
    JobVerification.IsVerified);
}
