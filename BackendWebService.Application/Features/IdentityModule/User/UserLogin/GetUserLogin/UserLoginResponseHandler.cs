using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class UserLoginResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserLoginRequest, UserLoginResponse>
{
 
    public IResponse<UserLoginResponse> Handle(UserLoginRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserLogin>().Get();

        var result = UserLoginResponse.FromEntity(entity);

        return Success(result);
    }
}