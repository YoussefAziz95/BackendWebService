using Domain;
using Domain.Enums;

namespace Application.Features;
public record JobVerificationResponse(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified);