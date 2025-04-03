using Application.Contracts.Persistence.Identities;
using Application.Contracts.Services;
using Application.DTOs.Auth.Request;
using Application.DTOs.Users;
using Application.DTOs.Suppliers.Request;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers
{
    /// <summary>
    /// Controller responsible for handling authentication-related actions.
    /// </summary>
    [Route("api/Admin")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : AppControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ISupplierService _supplierService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">Services to handle authentication.</param>
        /// <param name="supplierService">Services to handle supplier-related actions.</param>
        public AuthController(IAuthService authService,
            ISupplierService supplierService)
        {
            _authService = authService;
            _supplierService = supplierService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="request">The user registration details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AddUserRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Registers a new supplier.
        /// </summary>
        /// <param name="request">The supplier registration details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("registerSupplier")]
        [ModelValidator]
        public async Task<IActionResult> RegisterSupplierAsync([FromBody] AddSupplierRequest request)
        {

            var result = await _supplierService.AddUnregisteredAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="request">The login details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Logs in a user using an authenticator.
        /// </summary>
        /// <param name="request">The login authenticator details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("loginAuthenticator")]
        public async Task<IActionResult> LoginAuthenticatorAsync([FromBody] LoginAuthenticatorRequest request)
        {
            var result = await _authService.LoginAuthenticatorAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Confirms the OTP for the user.
        /// </summary>
        /// <param name="request">The OTP confirmation details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("confirmOtp")]
        [Authorize]
        public async Task<IActionResult> ConfirmOtp([FromBody] ConfirmOtpRequest request)
        {
            var result = await _authService.ConfirmOtp(request);
            if (result.Succeeded)
                HttpContext.Session.SetString(AppConstants.UserOtpType, "true");
            return NewResult(result);
        }

        /// <summary>
        /// Sends a password reset request.
        /// </summary>
        /// <param name="request">The forget password request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("forgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            var result = await _authService.ForgetPassword(request);
            return NewResult(result);
        }

        /// <summary>
        /// Resets the user password.
        /// </summary>
        /// <param name="request">The reset password request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authService.ResetPassword(request);
            return NewResult(result);
        }

        /// <summary>
        /// Resets the authenticated user's password.
        /// </summary>
        /// <param name="request">The reset password request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("resetPasswordAuth")]
        [Authorize]
        public async Task<IActionResult> ResetPasswordAuth([FromBody] ResetPasswordRequest request)
        {
            var result = await _authService.ResetPasswordAuth(request);
            return NewResult(result);
        }

        /// <summary>
        /// Sends an email confirmation request.
        /// </summary>
        /// <param name="email">The email confirmation request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("sendConfirmEmail")]
        public async Task<IActionResult> SendConfirmEmail([FromBody] SendConfirmEmailRequest email)
        {
            var result = await _authService.SendConfirmEmailAsync(email);
            return NewResult(result);
        }

        /// <summary>
        /// Confirms the user's email.
        /// </summary>
        /// <param name="request">The email confirmation details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            var result = await _authService.ConfirmEmailAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Sets the refresh token in a cookie.
        /// </summary>
        /// <param name="refreshToken">The refresh token value.</param>
        /// <param name="expires">The expiration date of the refresh token.</param>
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
