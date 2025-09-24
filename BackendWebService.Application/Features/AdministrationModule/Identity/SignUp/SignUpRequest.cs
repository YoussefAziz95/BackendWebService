using Application.Contracts.Features;

namespace Application.Features;
public record SignUpRequest(
string FirstName,
string LastName,
string Email,
string Password,
string PhoneNumber,
string MainRole,
string? Department,
string? Title) : IRequest<LoginResponse>;