using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserClaimAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserClaimAllRequest, List<UserClaimAllResponse>>
{
    public IResponse<List<UserClaimAllResponse>> Handle(UserClaimAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserClaim>().GetAll();

        var result = entity.Select(UserClaimAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

