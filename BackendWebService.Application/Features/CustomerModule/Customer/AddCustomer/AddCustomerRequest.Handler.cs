using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddCustomerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCustomerRequest, int>
{
    public IResponse<int> Handle(AddCustomerRequest request)
    {
        throw new NotImplementedException();
    }
}