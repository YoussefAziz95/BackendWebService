namespace Application.Features;

public record LoginResponse(int Id, string FullName, string PhoneNumber, string Email, string Token, DateTime TokenExpiry, string MainRole, string? Department, string? Title, bool IsActive);
