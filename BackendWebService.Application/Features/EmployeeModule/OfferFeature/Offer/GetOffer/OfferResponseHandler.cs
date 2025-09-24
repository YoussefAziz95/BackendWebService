using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class OfferResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OfferRequest, OfferResponse>
{

    public IResponse<OfferResponse> Handle(OfferRequest request)
    {
        var entity = unitOfWork.GenericRepository<Offer>().Get();

        var result = OfferResponse.FromEntity(entity);

        return Success(result);
    }
}