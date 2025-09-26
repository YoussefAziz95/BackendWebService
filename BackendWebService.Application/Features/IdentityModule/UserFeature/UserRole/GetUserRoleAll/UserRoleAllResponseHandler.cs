using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserRoleAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserRoleAllRequest, List<UserRoleAllResponse>>
{
    public IResponse<List<UserRoleAllResponse>> Handle(UserRoleAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserRole>().GetAll();

        var result = entity.Select(UserRoleAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

