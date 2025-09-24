using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Contracts.Services;
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
public class RefreshTokenRequestHandler(IUnitOfWork unitOfWork,
                                        IJwtService jwtService,
                                        IAppUserManager userManager)
    : ResponseHandler, IRequestHandlerAsync<RefreshTokenRequest, RefreshTokenResponse>
{
    public async Task<IResponse<RefreshTokenResponse>> HandleAsync(RefreshTokenRequest request)
    {
        var result = await jwtService.RefreshTokenAsync(request.Token);
        if (result == null)
            return Unauthorized<RefreshTokenResponse>("Invalid refresh token");

        var user = unitOfWork.GenericRepository<UserRefreshToken>().GetAll(include: ur => ur.Include(u => u.User)).Select(u => u.User).First();

        return new Response<RefreshTokenResponse>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Token refreshed",
            Succeeded = true,
            Data = new RefreshTokenResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                PhoneNumber: user.PhoneNumber!,
                Email: user.Email,
                Token: result.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
                Department: user.Department,
                Title: user.Title,
                IsActive: user.IsActive ?? true
            )
        };
    }
}