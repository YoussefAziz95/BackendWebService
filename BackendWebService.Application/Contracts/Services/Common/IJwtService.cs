using Application.Models.Jwt;
using Domain;
using System.Security.Claims;


namespace Contracts.Services;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
    Task<AccessToken> RefreshToken(int refreshTokenId);
    Task<AccessToken> RefreshTokenAsync(string token);
}