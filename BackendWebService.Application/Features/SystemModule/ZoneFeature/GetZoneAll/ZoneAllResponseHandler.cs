using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ZoneAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ZoneAllRequest, List<ZoneAllResponse>>
{
    public IResponse<List<ZoneAllResponse>> Handle(ZoneAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Zone>().GetAll();

        var result = entity.Select(ZoneAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

