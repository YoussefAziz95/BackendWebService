using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserGroupResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserGroupResponse>
{

    public IResponse<UserGroupResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<UserGroup>().GetById(id);

        var result = UserGroupResponse.FromEntity(entity);

        return Success(result);
    }
}