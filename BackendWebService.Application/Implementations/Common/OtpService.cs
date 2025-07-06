using Application.Contracts.AppManager;
using Application.Contracts.Services;
using Domain;

namespace Application.Implementations.Common;

public class OtpService : IOtpService
{
    private readonly IAppUserManager _userManager;
    private const int OTP_EXPIRATION_MINUTES = 5; // OTP expiration time
    private const int MAX_OTP_ATTEMPTS = 5; // Max failed OTP attempts before blocking
    public OtpService(IAppUserManager appUserManager)
    {
        _userManager = appUserManager;
    }
    public async Task<string> SendOTP(User user)
    {
        var otp = new Random().Next(100000, 999999).ToString();
        await _userManager.SetAuthenticationTokenAsync(user, "RFA", "OTP", otp);
        await _userManager.SetAuthenticationTokenAsync(user, "RFA", "OTP_TIME", DateTime.UtcNow.ToString());
        return otp;
    }

    public async Task<bool> VerifyAsync(User user, string code)
    {
        var storedOtp = await _userManager.GetAuthenticationTokenAsync(user, "RFA", "OTP");
        var otpTime = await _userManager.GetAuthenticationTokenAsync(user, "RFA", "OTP_TIME");

        if (string.IsNullOrEmpty(storedOtp) || string.IsNullOrEmpty(otpTime))
            return false;

        // Check OTP expiration
        if (DateTime.UtcNow.Subtract(DateTime.Parse(otpTime)).TotalMinutes > OTP_EXPIRATION_MINUTES)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, "RFA", "OTP");
            await _userManager.RemoveAuthenticationTokenAsync(user, "RFA", "OTP_TIME");
            return false;
        }

        if (storedOtp != code)
        {
            return false;
        }

        // Remove OTP after successful verification
        await _userManager.RemoveAuthenticationTokenAsync(user, "RFA", "OTP");
        await _userManager.RemoveAuthenticationTokenAsync(user, "RFA", "OTP_TIME");
        return true;
    }
}
