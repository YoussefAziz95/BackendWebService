using Application.DTOs.Common;
using Application.DTOs.Users;
using Application.DTOs.Auths;
using Application.DTOs.Auths.Response;
using Application.Contracts.DTOs;

namespace Application.Contracts.Services;
public interface IAuthService
{
    Task<IResponse<AuthResponse>> RegisterAsync(AddUserRequest request);
    Task<IResponse<AuthResponse>> LoginAsync(LoginRequest request);
    Task<IResponse<AuthResponse>> LoginAuthenticatorAsync(LoginAuthenticatorRequest request);
    Task<IResponse<AuthResponse>> RefreshTokenAsync(string token);
    Task<IResponse<bool>> RevokeTokenAsync(string token);
    Task<IResponse<bool>> ConfirmOtp(ConfirmOtpRequest request);
    Task<IResponse<bool>> SendConfirmEmailAsync(SendConfirmEmailRequest request);
    Task<IResponse<bool>> ConfirmEmailAsync(ConfirmEmailRequest request);
    Task<IResponse<string>> ForgetPassword(ForgetPasswordRequest request);
    Task<IResponse<string>> ResetPassword(ResetPasswordRequest request);
    Task<IResponse<string>> ResetPasswordAuth(ResetPasswordRequest request);
    Task<IResponse<bool>> DeleteSuperPassword(DeleteSuperPasswordRequest request);
}
