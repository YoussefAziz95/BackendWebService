using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Wrappers;

namespace Application.Features;
public class ResetPasswordRequestHandler(IAppUserManager userManager) : ResponseHandler, IRequestHandlerAsync<ResetPasswordRequest, LoginResponse>
{
    public async Task<IResponse<LoginResponse>> HandleAsync(ResetPasswordRequest request)
    {
        var user = await userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest<LoginResponse>("User not found.");


        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        // Send token via email or SMS here
        return Ok<LoginResponse>(message: "Password reset instructions sent. " + token);
    }
}