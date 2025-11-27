using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserTokenResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserTokenResponse>
{

    public IResponse<UserTokenResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<UserToken>().GetById(id);

        var result = UserTokenResponse.FromEntity(entity);

        return Success(result);
    }
}