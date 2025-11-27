using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OfferItemAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OfferItemAllRequest, List<OfferItemAllResponse>>
{
    public IResponse<List<OfferItemAllResponse>> Handle(OfferItemAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<OfferItem>().GetAll();

        var result = entity.Select(OfferItemAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

