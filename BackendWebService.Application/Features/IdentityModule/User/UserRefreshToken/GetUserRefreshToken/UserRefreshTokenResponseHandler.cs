using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class UserRefreshTokenResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserRefreshTokenRequest, UserRefreshTokenResponse>
{
 
    public IResponse<UserRefreshTokenResponse> Handle(UserRefreshTokenRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserRefreshToken>().Get();

        var result = UserRefreshTokenResponse.FromEntity(entity);

        return Success(result);
    }
}