using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserTokenResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserTokenRequest, UserTokenResponse>
{

    public IResponse<UserTokenResponse> Handle(UserTokenRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserToken>().Get();

        var result = UserTokenResponse.FromEntity(entity);

        return Success(result);
    }
}