using BackendWebService.Application.Models.Jwt;
using Domain;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BackendWebService.Application.Contracts;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
    Task<AccessToken> RefreshToken(int refreshTokenId);
}