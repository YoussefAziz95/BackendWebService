using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OfferItemResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<OfferItemResponse>
{

    public IResponse<OfferItemResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<OfferItem>().GetById(id);

        var result = OfferItemResponse.FromEntity(entity);

        return Success(result);
    }
}