using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateJobVerificationRequest(
 int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified);