using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class RoleResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RoleRequest, RoleResponse>
{

    public IResponse<RoleResponse> Handle(RoleRequest request)
    {
        var entity = unitOfWork.GenericRepository<Role>().Get();

        var result = RoleResponse.FromEntity(entity);

        return Success(result);
    }
}