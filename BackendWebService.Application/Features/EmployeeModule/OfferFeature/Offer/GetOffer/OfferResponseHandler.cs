using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OfferResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<OfferResponse>
{

    public IResponse<OfferResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Offer>().GetById(id);

        var result = OfferResponse.FromEntity(entity);

        return Success(result);
    }
}