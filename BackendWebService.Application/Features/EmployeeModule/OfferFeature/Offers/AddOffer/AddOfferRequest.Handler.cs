using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddOfferRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOfferRequest, int>
{
    public IResponse<int> Handle(AddOfferRequest request)
    {
        throw new NotImplementedException();
    }
}