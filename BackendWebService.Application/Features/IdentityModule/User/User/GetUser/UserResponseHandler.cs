using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserRequest, UserResponse>
{

    public IResponse<UserResponse> Handle(UserRequest request)
    {
        var entity = unitOfWork.GenericRepository<User>().Get();

        var result = UserResponse.FromEntity(entity);

        return Success(result);
    }
}