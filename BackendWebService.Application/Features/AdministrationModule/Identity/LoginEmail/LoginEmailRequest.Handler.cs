using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Contracts.Services;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;

public class LoginEmailRequestHandler(IAppUserManager userManager,
                                        IJwtService jwtService) : ResponseHandler, IRequestHandlerAsync<LoginEmailRequest, LoginResponse>
{
    public async Task<IResponse<LoginResponse>> HandleAsync(LoginEmailRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email.Trim());

        if (user == null)
            return Unauthorized<LoginResponse>();

        //if (!user.PhoneNumberConfirmed)
        //    return Forbid("Phone Number not confirmed");

        var result = await userManager.CheckPasswordAsync(user, request.Password);


        if (!result)
            return Unauthorized<LoginResponse>();

        var roles = await userManager.GetRolesAsync(user);

        var accessToken = await jwtService.GenerateAsync(user);
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
               Token: accessToken.access_token,
                RefreshToken: accessToken.refresh_token,
               TokenExpiry: DateTime.UtcNow.AddMinutes(30),
               MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
               Department: user.Department,
               Title: user.Title,
               IsActive: user.IsActive ?? true
           )
        };


        return response;
    }
}
