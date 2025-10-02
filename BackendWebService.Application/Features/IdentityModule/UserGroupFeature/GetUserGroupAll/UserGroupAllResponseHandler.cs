using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserGroupAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserGroupAllRequest, List<UserGroupAllResponse>>
{
    public IResponse<List<UserGroupAllResponse>> Handle(UserGroupAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserGroup>().GetAll();

        var result = entity.Select(UserGroupAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

