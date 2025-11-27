using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OfferAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OfferAllRequest, List<OfferAllResponse>>
{
    public IResponse<List<OfferAllResponse>> Handle(OfferAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Offer>().GetAll();

        var result = entity.Select(OfferAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

