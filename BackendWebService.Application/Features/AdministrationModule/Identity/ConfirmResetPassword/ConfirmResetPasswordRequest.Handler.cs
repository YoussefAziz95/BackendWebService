using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;
public class ConfirmResetPasswordRequestHandler(IAppUserManager userManager) : ResponseHandler, IRequestHandlerAsync<ConfirmResetPasswordRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(ConfirmResetPasswordRequest request)
    {
        var user = await userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest<string>("Invalid request.");

        var result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        return result.Succeeded ? Success("Password reset successfully.") : BadRequest<string>("Invalid request.");
    }
}