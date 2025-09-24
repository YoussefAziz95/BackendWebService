using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class SpareResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<SpareRequest, SpareResponse>
{

    public IResponse<SpareResponse> Handle(SpareRequest request)
    {
        var entity = unitOfWork.GenericRepository<Spare>().Get();

        var result = SpareResponse.FromEntity(entity);

        return Success(result);
    }
}