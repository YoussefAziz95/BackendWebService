using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class OfferObjectResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OfferObjectRequest, OfferObjectResponse>
{
 
    public IResponse<OfferObjectResponse> Handle(OfferObjectRequest request)
    {
        var entity = unitOfWork.GenericRepository<OfferObject>().Get();

        var result = OfferObjectResponse.FromEntity(entity);

        return Success(result);
    }
}