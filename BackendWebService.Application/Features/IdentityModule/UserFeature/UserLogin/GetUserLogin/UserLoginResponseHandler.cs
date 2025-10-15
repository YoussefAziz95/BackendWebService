using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserLoginResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserLoginResponse>
{

    public IResponse<UserLoginResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<UserLogin>().GetById(id);

        var result = UserLoginResponse.FromEntity(entity);

        return Success(result);
    }
}