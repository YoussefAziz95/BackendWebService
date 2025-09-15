using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateOfferRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateOfferRequest, int>
{
    public IResponse<int> Handle(UpdateOfferRequest request)
    {
        throw new NotImplementedException();
    }
}