using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;
public class ConfirmPhoneNumberRequestHandler(IAppUserManager userManager, IOtpService otpService) : ResponseHandler, IRequestHandlerAsync<ConfirmPhoneNumberRequest, IdentityResult>
{
    public async Task<IResponse<IdentityResult>> HandleAsync(ConfirmPhoneNumberRequest request)
    {
        var user = await userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest<IdentityResult>("Invalid request.");

        var result = await otpService.VerifyAsync(user, request.Code);
        if (!result)
            return BadRequest<IdentityResult>("Invalid token");
        var response = await userManager.ConfirmPhoneNumberAsync(user);
        return response.Succeeded ? Success(response) : BadRequest<IdentityResult>();
    }
}
