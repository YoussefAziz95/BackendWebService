using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateOfferItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateOfferItemRequest, int>
{
    public IResponse<int> Handle(UpdateOfferItemRequest request)
    {
        throw new NotImplementedException();
    }
}