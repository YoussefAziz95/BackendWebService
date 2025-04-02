using Application.Contracts.Presistence;
using Application.Contracts.Services;
using Application.Model.Jwt;
using Domain.Constants;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Implementations
{
    /// <summary>
    /// Service for generating JSON Web Tokens (JWT) for user authentication.
    /// </summary>
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthenticationFactory _authenticationFactory;

        /// <summary>
        /// Constructor for JwtProvider.
        /// </summary>
        /// <param name="jwtOptions">The JWT options.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="authenticationFactory">The authentication factory.</param>
        public JwtProvider(IOptions<JwtOptions> jwtOptions,
                           UserManager<User> userManager,
                           RoleManager<Role> roleManager,
                           IUnitOfWork unitOfWork,
                           AuthenticationFactory authenticationFactory)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _authenticationFactory = authenticationFactory;
        }

        /// <inheritdoc/>
        public async Task<string> Generate(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var permissions = GetClaims(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim(AppConstants.roles, role));


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
        }
            .Union(userClaims)
            .Union(permissions)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwtOptions.DurationInHours),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>();
            var roles = _userManager.GetRolesAsync(user).Result.ToList();
            foreach (var role in roles)
            {
                var appRole = _unitOfWork.GenericRepository<Role>().Get(r => r.Name == role);
                if (appRole != null)
                    claims.AddRange(_roleManager.GetClaimsAsync(appRole).Result);
            }
            return claims;
        }
    }
}
