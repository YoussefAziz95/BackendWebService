using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserRefreshTokenResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserRefreshTokenResponse>
{

    public IResponse<UserRefreshTokenResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<UserRefreshToken>().GetById(id);

        var result = UserRefreshTokenResponse.FromEntity(entity);

        return Success(result);
    }
}