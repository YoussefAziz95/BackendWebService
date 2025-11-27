using Application.Contracts.Features;

namespace Application.Features;
public record LoginResponse(
int Id,
string FullName,
string PhoneNumber,
string Email,
string Token,
string RefreshToken,
DateTime TokenExpiry,
string MainRole,
string? Department,
string? Title,
bool IsActive) : IRequest<int>;
