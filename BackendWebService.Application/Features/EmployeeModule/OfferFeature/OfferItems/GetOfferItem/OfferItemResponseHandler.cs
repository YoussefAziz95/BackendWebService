using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class OfferItemResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OfferItemRequest, OfferItemResponse>
{
 
    public IResponse<OfferItemResponse> Handle(OfferItemRequest request)
    {
        var entity = unitOfWork.GenericRepository<OfferItem>().Get();

        var result = OfferItemResponse.FromEntity(entity);

        return Success(result);
    }
}