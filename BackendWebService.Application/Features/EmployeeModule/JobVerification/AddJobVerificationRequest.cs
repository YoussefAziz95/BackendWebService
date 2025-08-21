using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddJobVerificationRequest(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified);