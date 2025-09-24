using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class SparePartResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<SparePartRequest, SparePartResponse>
{

    public IResponse<SparePartResponse> Handle(SparePartRequest request)
    {
        var entity = unitOfWork.GenericRepository<SparePart>().Get();

        var result = SparePartResponse.FromEntity(entity);

        return Success(result);
    }
}