using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserRoleResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserRoleRequest, UserRoleResponse>
{

    public IResponse<UserRoleResponse> Handle(UserRoleRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserRole>().Get();

        var result = UserRoleResponse.FromEntity(entity);

        return Success(result);
    }
}