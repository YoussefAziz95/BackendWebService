using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class SparePartAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<SparePartAllRequest, List<SparePartAllResponse>>
{
    public IResponse<List<SparePartAllResponse>> Handle(SparePartAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<SparePart>().GetAll();

        var result = entity.Select(SparePartAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

