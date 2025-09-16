using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateAddressRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateAddressRequest, int>
{
    public IResponse<int> Handle(UpdateAddressRequest request)
    {
        throw new NotImplementedException();
    }
}