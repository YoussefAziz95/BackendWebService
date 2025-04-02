using Application.Contracts.DTOs;
using Application.Contracts.Infrastructure;
using Application.Contracts.Presistence;
using Application.Contracts.Presistence.Identities;
using Application.Contracts.Services;
using Application.DTOs.Auth.Request;
using Application.DTOs.Auth.Response;
using Application.DTOs.Common;
using Application.DTOs.User;
using Application.Model.EmailDto;
using Application.Validators.Auth;
using Application.Wrappers;


using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Application.Implementations
{
    /// <summary>
    /// Service for handling authentication operations.
    /// </summary>
    public sealed class AuthService : ResponseHandler, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtProvider _jwtProvider;
        private readonly AuthenticationFactory _authenticationFactory;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor for AuthService.
        /// </summary>
        public AuthService(UserManager<User> userManager,
                           IJwtProvider jwtProvider,
                           AuthenticationFactory authenticationFactory,
                           IEmailService emailService,
                           IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
            _authenticationFactory = authenticationFactory;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<bool>> ConfirmEmailAsync(ConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var result = await _userManager.ConfirmEmailAsync(user!, request.Token);
            return result.Succeeded ? EmailVerified<bool>() : BadRequest<bool>();
        }
        public async Task<IResponse<bool>> ConfirmOtp(ConfirmOtpRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user.Otps.Where(otp => otp.Code == request.Otp && !otp.IsExpired).Any() == null)
                return Unauthorized<bool>();
            user.Otps.Where(otp => otp.Code == request.Otp && !otp.IsExpired).FirstOrDefault().IsUsed = true;
            await _userManager.UpdateAsync(user);
            return Success(true);
        }
        public async Task<IResponse<AuthResponse>> LoginAuthenticatorAsync(LoginAuthenticatorRequest request)
        {
            var authResult = new AuthResponse();
            var authenticationService = _authenticationFactory.RetrieveAuthenticateService(request);
            var isAuthenticated = await authenticationService.IsAuthenticated();
            if (!isAuthenticated)
                return Unauthorized<AuthResponse>();
            var user = await _userManager.FindByEmailAsync(authenticationService.getEmail());
            if (user is null)
                return Unauthorized<AuthResponse>();
            var token = await _jwtProvider.Generate(user);
            var roleList = await _userManager.GetRolesAsync(user);
            authResult.Token = token;
            authResult.UserId = user.Id;
            authResult.MainRole = Enum.GetName(user.MainRole);
            authResult.Username = user.UserName;
            authResult.IsAuthenticated = true;
            authResult.Email = user.Email;
            authResult.Roles = roleList.ToList();
            authResult.CompanyId = user.OrganizationId;
            if (user.RefreshTokens!.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens!.FirstOrDefault(t => t.IsActive);
                authResult.RefreshToken = activeRefreshToken!.Token;
                authResult.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authResult.RefreshToken = refreshToken.Token;
                authResult.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens!.Add(refreshToken);

            }
            authResult = await handleOtp(user, authResult);
            await _userManager.UpdateAsync(user);
            return Success(authResult);
        }

        public async Task<IResponse<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var authResult = new AuthResponse();
            var user = await _userManager.FindByEmailAsync(request.Email.ToUpper());
            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return Unauthorized<AuthResponse>();
            var token = await _jwtProvider.Generate(user);
            var roleList = await _userManager.GetRolesAsync(user);
            var organization = _unitOfWork.GenericRepository<Organization>().Get(x=> x.Id == user.OrganizationId);
            var role = _unitOfWork.GenericRepository<UserRole>().Get(x=> x.UserId == user.Id );
            authResult.Token = token;
            authResult.UserId = user.Id;
            authResult.MainRole = Enum.GetName(user.MainRole);
            authResult.Username = user.UserName;
            authResult.IsAuthenticated = true;
            authResult.Email = user.Email;
            authResult.Roles = roleList.ToList();
            authResult.OrganizationId = organization.Id;
            authResult.SupplierId = _unitOfWork.GenericRepository<Supplier>().Get(v => v.OrganizationId == organization.Id)?.Id;
            authResult.CompanyId = _unitOfWork.GenericRepository<Company>().Get(v => v.OrganizationId == organization.Id)?.Id;
            authResult.SupplierAccountId = _unitOfWork.GenericRepository<SupplierAccount>().Get(v => v.OrganizationId == (organization.Id))?.Id;
            authResult.RoleId = role.RoleId;
            authResult.OrganizationType = Enum.GetName(typeof(RoleEnum), organization.Type);
            if (user.RefreshTokens!.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens!.FirstOrDefault(t => t.IsActive);
                authResult.RefreshToken = activeRefreshToken!.Token;
                authResult.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authResult.RefreshToken = refreshToken.Token;
                authResult.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens!.Add(refreshToken);
            }
            authResult = await handleOtp(user, authResult);
            return Success(authResult);
        }

        public async Task<IResponse<AuthResponse>> RefreshTokenAsync(string token)
        {
            var authResult = new AuthResponse();
            var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens!.Any(t => t.Token == token));
            if (user is null)
                return BadRequest<AuthResponse>("Invalid Token");

            var refreshToken = user.RefreshTokens!.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
                return BadRequest<AuthResponse>("InActive Token");
            refreshToken.RevokedOn = DateTime.UtcNow;
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens!.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await _jwtProvider.Generate(user);
            authResult.UserId = user.Id;
            authResult.IsAuthenticated = true;
            authResult.Token = jwtToken;
            authResult.Email = user.Email;

            var roles = await _userManager.GetRolesAsync(user);
            authResult.Roles = roles.ToList();
            authResult.RefreshToken = newRefreshToken.Token;
            authResult.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return Success(authResult);
        }

        public async Task<IResponse<AuthResponse>> RegisterAsync(AddUserRequest request)
        {
            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                MainRole = Enum.Parse<RoleEnum>(request.MainRole),
                LastName = request.LastName,
                OrganizationId = IClientRepository._userInfo.OrganizationId,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return BadRequest<AuthResponse>(result.Errors.Select(e => e.Description).ToList());

            foreach (var role in request.Roles)
                await _userManager.AddToRoleAsync(user, role);
            var jwtSecurityToken = await _jwtProvider.Generate(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            var authResult = new AuthResponse
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
                IsAuthenticated = true,
                Roles = request.Roles,
                Token = jwtSecurityToken,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn,
                CompanyId = user.OrganizationId
            };
            return Success(authResult);
        }

        public async Task<IResponse<bool>> RevokeTokenAsync(string token)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens!.Any(t => t.Token == token));
            if (user is null)
                return BadRequest<bool>("Token is required!");

            var refreshToken = user.RefreshTokens!.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
                return BadRequest<bool>("Token is invalid!");

            refreshToken.RevokedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return Success(true);
        }

        public async Task<IResponse<bool>> SendConfirmEmailAsync(SendConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            SendConfirmationEmail(user);

            return Success(true);
        }
        public async Task<AuthResponse> handleOtp(User user, AuthResponse auth)
        {
            auth.HasOtp = user.HasOtp;
            if (!user.HasOtp)
                return auth;
            var otpsToRemove = new List<Otp>();
            foreach (Otp otp in user.Otps)
            {
                if (otp.IsExpired)
                    otpsToRemove.Add(otp);

            }
            foreach (Otp otpToRemove in otpsToRemove)
            {
                user.Otps.Remove(otpToRemove);
            }
            var Otp = new Otp();
            if (!user.Otps.Where(o => o.IsUsed).Any())
            {
                Otp = GenerateRefreshOtp();
                _emailService.Send(new EmailDto("OTP Confirmation", Otp.Code, user.Email, "", "", DateTime.Now, user.Id));
                user.Otps.Add(Otp);
                auth.IsOtpVerfied = false;
            }
            else
                auth.IsOtpVerfied = true;

            await _userManager.UpdateAsync(user);
            return auth;
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = RandomNumberGenerator.Create();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(1),
                CreatedOn = DateTime.UtcNow
            };
        }

        private Otp GenerateRefreshOtp()
        {
            var randomNumber = new byte[6];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            int numericCode = BitConverter.ToInt32(randomNumber, 0);
            numericCode = Math.Abs(numericCode);
            numericCode %= 1000000;

            return new Otp
            {
                IsUsed = false,
                Code = numericCode.ToString("D6"),
                ExpiresOn = DateTime.UtcNow.AddDays(1),
                CreatedOn = DateTime.UtcNow

            };
        }

        public async Task<IResponse<string>> ForgetPassword(ForgetPasswordRequest request)
        {
            var validator = new ForgetPasswordRequestValidator(_userManager);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                return BadRequest<string>(validatorResult.Errors.Select(e => e.ErrorMessage).ToList());

            var user = await _userManager.FindByEmailAsync(request.Email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
            try
            {
                Console.WriteLine(request.Email + " Token Is " + token);
                var emailSent = await _emailService.Send(new EmailDto("Reset Password Token", token, user.Email, "", "", DateTime.Now, user.Id));
                await _unitOfWork.SaveAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Success("Token Sent Successfully"); //removie the token here after implemnting the mail method
        }

        public async Task<IResponse<string>> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var result = await _userManager.ResetPasswordAsync(user!, request.Token, request.Password);
            return result.Succeeded ? PasswordUpdated<string>() : BadRequest<string>();
        }
        public async Task<IResponse<string>> ResetPasswordAuth(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            IdentityResult result = new IdentityResult();
            if (user is null)
                return BadRequest<string>("EmailDto is not Correct");
            if (!await _userManager.CheckPasswordAsync(user, request.OldPassword))
                return BadRequest<string>("Old Password is not Correct");
            result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.Password);

            return result.Succeeded ? PasswordUpdated<string>() : BadRequest<string>();
        }
        private async void SendConfirmationEmail(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailDTO = new EmailDto("EmailDto Confirmation", token.ToString(), user.Email, "", "", DateTime.Now, user.Id);

            _emailService.Send(emailDTO);
        }

        public async Task<IResponse<bool>> DeleteSuperPassword(DeleteSuperPasswordRequest request)
        {
            return Success<bool>(true);
        }
    }
}
