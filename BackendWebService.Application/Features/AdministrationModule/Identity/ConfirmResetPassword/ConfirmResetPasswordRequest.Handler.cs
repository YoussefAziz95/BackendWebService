using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
public class ConfirmResetPasswordRequestHandler(IAppUserManager userManager, IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<ConfirmResetPasswordRequest, LoginResponse>
{
    public async Task<IResponse<LoginResponse>> HandleAsync(ConfirmResetPasswordRequest request)
    {
        var user = await userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest<LoginResponse>("Invalid request.");

        var result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        var refreshToen = unitOfWork.GenericRepository<UserRefreshToken>().GetAll(t => t.UserId == user.Id).Last().Id;
        var response = new Response<LoginResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Login successful",
            Succeeded = true,
            Data = new LoginResponse(
              Id: user.Id,
              FullName: $"{user.FirstName} {user.LastName}",
              PhoneNumber: user.PhoneNumber!,
              Email: user.Email,
              Token: request.Token,
              RefreshToken: refreshToen.ToString(),
              TokenExpiry: DateTime.UtcNow.AddMinutes(30),
              MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
              Department: user.Department,
              Title: user.Title,
              IsActive: user.IsActive ?? true
          )
        };
        return result.Succeeded ? Success<LoginResponse>("Password reset successfully.") : BadRequest<LoginResponse>("Invalid request.");
    }
}