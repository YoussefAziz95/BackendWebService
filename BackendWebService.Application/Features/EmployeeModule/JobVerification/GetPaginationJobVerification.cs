using Domain;
using Domain.Enums;

namespace Application.Features;
public record GetPaginatedJobVerification(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified);