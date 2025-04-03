using Application.Contracts.DTOs;
using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Identities;
using Application.Contracts.Services;
using Application.DTOs.Auth.Request;
using Application.DTOs.Auth.Response;
using Application.DTOs.Common;
using Application.DTOs.Users;
using Application.Model.EmailDto;
using Application.Validators.Auth;
using Application.Wrappers;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace Application.Implementations
{
    /// <summary>
    /// Services for handling authentication operations.
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
            var authenticationService = _authenticationFactory.RetrieveAuthenticateService(request);
            var isAuthenticated = await authenticationService.IsAuthenticated();
            if (!isAuthenticated)
                return Unauthorized<AuthResponse>();
            var user = await _userManager.FindByEmailAsync(authenticationService.getEmail());
            if (user is null)
                return Unauthorized<AuthResponse>();
            var token = await _jwtProvider.Generate(user);
            var roleList = await _userManager.GetRolesAsync(user);
            var authResult = new AuthResponse()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Department = user.Department,
                Title = user.Title,
                MainRole = Enum.GetName(user.MainRole),
                Username = user.UserName,
            };
            await _userManager.UpdateAsync(user);
            return Success(authResult);
        }

        public async Task<IResponse<AuthResponse>> LoginAsync(LoginRequest request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email.ToUpper());
            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return Unauthorized<AuthResponse>();
            var token = await _jwtProvider.Generate(user);
            var roleList = await _userManager.GetRolesAsync(user);
            var organization = _unitOfWork.GenericRepository<Organization>().Get(x => x.Id == user.OrganizationId);
            var authResult = new AuthResponse()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Department = user.Department,
                Title = user.Title,
                MainRole = Enum.GetName(user.MainRole),
                Username = user.UserName,
            };


            return Success(authResult);
        }

        public async Task<IResponse<AuthResponse>> RefreshTokenAsync(string token)
        {

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

            var roles = await _userManager.GetRolesAsync(user);
            var authResult = new AuthResponse()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Department = user.Department,
                Title = user.Title,
                Username = user.UserName,
                MainRole = Enum.GetName(user.MainRole),
            };
            return Success(authResult);
        }

        public async Task<IResponse<AuthResponse>> RegisterAsync(AddUserRequest request)
        {
            RoleEnum mainRole;
            Role role = _unitOfWork.GenericRepository<Role>().Get(r => r.Name == request.MainRole);
            if (!Enum.TryParse(request.MainRole, out mainRole))
            {
                var parentId = role.ParentId ?? (int)RoleEnum.Customer;
                mainRole = (RoleEnum)parentId;
            }

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                MainRole = mainRole,
                LastName = request.LastName,
                OrganizationId = IClientRepository._userInfo.OrganizationId,
                IsDefaultPassword = true,
                IsActive = true,
                IsSystem = false,
                PhoneNumber = request.PhoneNumber,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                IsDeleted = false,
                CreatedBy = IClientRepository._userInfo.Username,
                CreatedDate = DateTime.UtcNow,
                Department = request.Department,
                Title = request.Title,
                NormalizedEmail = request.Email.ToUpper(),
                NormalizedPhoneNumber = request.PhoneNumber.ToUpper(),
                PhoneNumberInternational = request.PhoneNumber,
                HasOtp = false


            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return BadRequest<AuthResponse>(result.Errors.Select(e => e.Description).ToList());
            if (role is not null)
                await _userManager.AddToRoleAsync(user, role.Name);

            var jwtSecurityToken = await _jwtProvider.Generate(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            var authResult = new AuthResponse
            {
                Email = user.Email,
                Username = user.UserName,
                Department = user.Department,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
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
        //public async Task<AuthResponse> handleOtp(Users user, AuthResponse auth)
        //{
        //    auth.HasOtp = user.HasOtp;
        //    if (!user.HasOtp)
        //        return auth;
        //    var otpsToRemove = new List<Otp>();
        //    foreach (Otp otp in user.Otps)
        //    {
        //        if (otp.IsExpired)
        //            otpsToRemove.Add(otp);

        //    }
        //    foreach (Otp otpToRemove in otpsToRemove)
        //    {
        //        user.Otps.Remove(otpToRemove);
        //    }
        //    var Otp = new Otp();
        //    if (!user.Otps.Where(o => o.IsUsed).Any())
        //    {
        //        Otp = GenerateRefreshOtp();
        //        _emailService.Send(new EmailDto("OTP Confirmation", Otp.Code, user.Email, "", "", DateTime.Now, user.Id));
        //        user.Otps.Add(Otp);
        //        auth.IsOtpVerfied = false;
        //    }
        //    else
        //        auth.IsOtpVerfied = true;

        //    await _userManager.UpdateAsync(user);
        //    return auth;
        //}
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
