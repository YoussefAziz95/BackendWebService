using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Wrappers;
using Contracts.Services;
using Domain;
using Domain.Enums;

namespace Application.Features;

public class SignUpRequestHandler(IAppUserManager userManager, IJwtService jwtService)
    : ResponseHandler, IRequestHandlerAsync<SignUpRequest, LoginResponse>
{

    public async Task<IResponse<LoginResponse>> HandleAsync(SignUpRequest request)
    {
        if (!Enum.TryParse<RoleEnum>(request.MainRole, out var mainRole))
        {
            return BadRequest<LoginResponse>("Invalid role specified");
        }

        var user = new User
        {
            UserName = request.Email.Trim().ToLower(),
            Email = request.Email.Trim().ToLower(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            MainRole = mainRole,
            Department = request.Department,
            Title = request.Title
        };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest<LoginResponse>("Invalid Password");
        }
        var accessToken = await jwtService.GenerateAsync(user);
        var response = new LoginResponse(
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
                IsActive: user.IsActive ?? true);

        return Success(response);
    }

}
