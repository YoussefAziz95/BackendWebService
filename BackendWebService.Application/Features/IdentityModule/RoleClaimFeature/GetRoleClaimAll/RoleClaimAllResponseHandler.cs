using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class RoleClaimAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RoleClaimAllRequest, List<RoleClaimAllResponse>>
{
    public IResponse<List<RoleClaimAllResponse>> Handle(RoleClaimAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<RoleClaim>().GetAll();

        var result = entity.Select(RoleClaimAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

