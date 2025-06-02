using Domain.Enums;
namespace Application.DTOs;

public record LoginRequest(string PhoneNumber, string Password);
public record LoginEmailRequest(string Email, string Password);
public record CreateUserWithPasswordRequest(string FirstName, string LastName, string Email, string Password, string PhoneNumber, string MainRole, string? Department, string? Title);
public record LoginAuthenticatorRequest(string ClientId, string AccessToken);
public record ExternalLoginRequest(string Provider, string ProviderKey);
public record RecoveryCodeRequest(string RecoveryCode);
public record TwoFactorRequest(string Code, bool RememberMe = false, bool RememberClient = false);
public record LoginResponse(int Id, string FullName, string PhoneNumner, string Email, string Token, DateTime TokenExpiry, string MainRole, string? Department, string? Title, bool IsActive);
public record RoleAssignRequest(int UserId, string Role);
public record RefreshTokenRequest(string Token);
public record ResetPasswordRequest(string PhoneNumber);
public record ConfirmResetPasswordRequest(string PhoneNumber, string Token, string NewPassword);
public record VerifyEmailRequest(string PhoneNumber, string Token);
public record ConfirmPhoneNumberRequest(string PhoneNumber, string Code);
public record MfaRequest(string PhoneNumber);
public record MfaVerifyRequest(string PhoneNumber, string Code);
public record PhoneNumberRequest(string PhoneNumber);
public record OtpVerify(string PhoneNumber, string Code);
    