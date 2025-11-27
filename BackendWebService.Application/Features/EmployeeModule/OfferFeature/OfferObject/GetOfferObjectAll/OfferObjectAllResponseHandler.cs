using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OfferObjectAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OfferObjectAllRequest, List<OfferObjectAllResponse>>
{
    public IResponse<List<OfferObjectAllResponse>> Handle(OfferObjectAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<OfferObject>().GetAll();

        var result = entity.Select(OfferObjectAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

