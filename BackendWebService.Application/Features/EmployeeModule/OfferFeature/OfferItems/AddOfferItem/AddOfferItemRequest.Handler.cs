using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddOfferItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOfferItemRequest, int>
{
    public IResponse<int> Handle(AddOfferItemRequest request)
    {
        throw new NotImplementedException();
    }
}