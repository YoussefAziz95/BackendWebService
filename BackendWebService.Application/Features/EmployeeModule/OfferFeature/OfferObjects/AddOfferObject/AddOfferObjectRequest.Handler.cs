using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddOfferObjectRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOfferObjectRequest, int>
{
    public IResponse<int> Handle(AddOfferObjectRequest request)
    {
        throw new NotImplementedException();
    }
}