using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserGroupResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserGroupRequest, UserGroupResponse>
{

    public IResponse<UserGroupResponse> Handle(UserGroupRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserGroup>().Get();

        var result = UserGroupResponse.FromEntity(entity);

        return Success(result);
    }
}