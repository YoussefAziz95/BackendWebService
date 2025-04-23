using Domain;

namespace Application.Contracts.Services;

public interface IOtpService
{
    Task<bool> VerifyAsync(User user, string code);
    Task<string> SendOTP(User user);
}
