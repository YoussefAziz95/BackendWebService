using Application.Contracts.Persistence;
using Application.Features;
using Application.Model.Jwt;
using Application.Models.Jwt;
using Contracts.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Identity.Jwt;

public class JwtService : IJwtService
{
    private readonly IdentitySettings _siteSetting;
    private readonly UserManager<User> _userManager;
    private readonly IUserClaimsPrincipalFactory<User> _claimsPrincipal;
    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

    private readonly IUnitOfWork _unitOfWork;
    //private readonly AppUserClaimsPrincipleFactory claimsPrincipleFactory;

    public JwtService(IOptions<IdentitySettings> siteSetting,
        UserManager<User> userManager, IUserClaimsPrincipalFactory<User> claimsPrincipal,
        IUnitOfWork unitOfWork,
        IUserRefreshTokenRepository userRefreshTokenRepository)
    {
        _siteSetting = siteSetting.Value;
        _userManager = userManager;
        _claimsPrincipal = claimsPrincipal;
        _unitOfWork = unitOfWork;
        _userRefreshTokenRepository = userRefreshTokenRepository;
    }
    public async Task<AccessToken> GenerateAsync(User user)
    {
        var secretKey = Encoding.UTF8.GetBytes(_siteSetting.SecretKey); // longer that 16 character
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

        //var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.Encryptkey); //must be 16 character
        //var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);


        var claims = await _getClaimsAsync(user);

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _siteSetting.Issuer,
            Audience = _siteSetting.Audience,
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.Now.AddMinutes(0),
            Expires = DateTime.Now.AddMinutes(_siteSetting.ExpirationMinutes),
            SigningCredentials = signingCredentials,
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);


        var token = new UserRefreshToken { IsValid = true, UserId = user.Id };
        await _unitOfWork.GenericRepository<UserRefreshToken>().AddAsync(token);
        await _unitOfWork.CommitAsync();
        var result = await _unitOfWork.SaveAsync();
        return new AccessToken(securityToken, token.Id.ToString());
    }

    public Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_siteSetting.SecretKey)),
            ValidateLifetime = false,
            TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_siteSetting.Encryptkey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return Task.FromResult(principal);
    }

    public async Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber)
    {
        var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        var result = await this.GenerateAsync(user);
        return result;
    }

    public async Task<AccessToken> RefreshToken(Guid refreshTokenId)
    {
        var refreshToken = await _userRefreshTokenRepository.GetTokenWithInvalidation(refreshTokenId);

        if (refreshToken is null)
            return null;

        refreshToken.IsValid = false;

        await _unitOfWork.SaveAsync();

        var user = await _userRefreshTokenRepository.GetUserByRefreshToken(refreshTokenId);

        if (user is null)
            return null;

        var result = await this.GenerateAsync(user);

        return result;
    }

    private async Task<IEnumerable<Claim>> _getClaimsAsync(User user)
    {
        var result = await _claimsPrincipal.CreateAsync(user);
        return result.Claims;
    }
    public async Task<AccessToken> RefreshTokenAsync(string token)
    {
        // Try parsing refreshToken ID (assuming it's an int like in your original implementation)
        if (!Guid.TryParse(token, out var refreshTokenId))
            return null;

        return await RefreshToken(refreshTokenId);
    }
    /// <summary>
    /// Retrieves the pages accessible to a user.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <returns>A response containing the pages accessible to the user.</returns>
    public IEnumerable<UserPagesResponse> GetUserPages(int id)
    {
        // Get all roles with their claims for the user
        var userRoles = _unitOfWork.GenericRepository<UserRole>()
            .GetAll(ur => ur.UserId == id, include: ur => ur.Include(ur => ur.Role).ThenInclude(r => r.Claims))
            .First();


        var claims = userRoles.Role.Claims
            .Select(parts => new UserPagesResponse
            (
                parts.Id,
                parts.ClaimType?.Split('.')[0],
                parts.ClaimType?.Split('.')[1],
                parts.ClaimType?.Split('.')[2],
                parts.ClaimType?.Split('.')[3],
                parts.ClaimType
            ))
            .ToList();

        return claims;
    }

}