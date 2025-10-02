using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class RoleResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<RoleResponse>
{

    public IResponse<RoleResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Role>().GetById(id);

        var result = RoleResponse.FromEntity(entity);

        return Success(result);
    }
}