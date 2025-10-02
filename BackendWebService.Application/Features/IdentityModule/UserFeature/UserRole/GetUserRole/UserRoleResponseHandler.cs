using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserRoleResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserRoleResponse>
{

    public IResponse<UserRoleResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<UserRole>().GetById(id);

        var result = UserRoleResponse.FromEntity(entity);

        return Success(result);
    }
}