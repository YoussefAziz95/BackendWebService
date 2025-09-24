using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateOfferObjectRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateOfferObjectRequest, int>
{
    public IResponse<int> Handle(UpdateOfferObjectRequest request)
    {
        throw new NotImplementedException();
    }
}