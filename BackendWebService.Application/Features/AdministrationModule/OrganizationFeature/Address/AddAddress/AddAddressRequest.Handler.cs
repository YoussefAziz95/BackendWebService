using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddAddressRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddAddressRequest, int>
{
    public IResponse<int> Handle(AddAddressRequest request)
    {
        throw new NotImplementedException();
    }
}