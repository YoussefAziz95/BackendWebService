using Domain.Enums;
namespace BackendWebService.Application.DTOs;

public record LoginRequest(string Email, string Password);
public record CreateUserWithPasswordRequest(string FirstName, string LastName, string Email, string Password, string? PhoneNumber, RoleEnum MainRole, string? Department, string? Title);
public record LoginAuthenticatorRequest(string ClientId, string AccessToken);
public record ExternalLoginRequest(string Provider, string ProviderKey);
public record RecoveryCodeRequest(string RecoveryCode);
public record TwoFactorRequest(string Code, bool RememberMe = false, bool RememberClient = false);
public record LoginResponse(int Id, string FullName, string Email, string Token, DateTime TokenExpiry, RoleEnum MainRole, string? Department, string? Title, bool IsActive);