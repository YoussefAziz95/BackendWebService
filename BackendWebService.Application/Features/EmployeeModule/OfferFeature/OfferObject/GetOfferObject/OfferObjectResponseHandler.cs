using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OfferObjectResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<OfferObjectResponse>
{

    public IResponse<OfferObjectResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<OfferObject>().GetById(id);

        var result = OfferObjectResponse.FromEntity(entity);

        return Success(result);
    }
}