using Domain.Enums;
namespace Application.DTOs;

public record LoginRequest(string PhoneNumber, string Password);
public record CreateUserWithPasswordRequest(string FirstName, string LastName, string Email, string Password, string? PhoneNumber, string MainRole, string? Department, string? Title);
public record LoginAuthenticatorRequest(string ClientId, string AccessToken);
public record ExternalLoginRequest(string Provider, string ProviderKey);
public record RecoveryCodeRequest(string RecoveryCode);
public record TwoFactorRequest(string Code, bool RememberMe = false, bool RememberClient = false);
public record LoginResponse(int Id, string FullName, string Email, string Token, DateTime TokenExpiry, RoleEnum MainRole, string? Department, string? Title, bool IsActive);
public record RoleAssignRequest(int UserId, string Role);
public record RefreshTokenRequest(string Token, string RefreshToken);
public record ResetPasswordRequest(string Email);
public record ConfirmResetPasswordRequest(string Email, string Token, string NewPassword);
public record VerifyEmailRequest(string Email, string Token);
public record MfaRequest(string Email);
public record MfaVerifyRequest(string Email, string Code);
