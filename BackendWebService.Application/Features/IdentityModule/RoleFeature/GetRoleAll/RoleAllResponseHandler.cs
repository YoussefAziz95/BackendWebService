using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class RoleAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RoleAllRequest, List<RoleAllResponse>>
{
    public IResponse<List<RoleAllResponse>> Handle(RoleAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Role>().GetAll();

        var result = entity.Select(RoleAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

