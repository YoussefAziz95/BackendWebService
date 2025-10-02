using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserResponse>
{

    public IResponse<UserResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<User>().GetById(id);

        var result = UserResponse.FromEntity(entity);

        return Success(result);
    }
}