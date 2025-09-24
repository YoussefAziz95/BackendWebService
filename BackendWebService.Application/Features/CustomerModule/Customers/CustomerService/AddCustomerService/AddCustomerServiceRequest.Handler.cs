using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddCustomerServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCustomerServiceRequest, int>
{
    public IResponse<int> Handle(AddCustomerServiceRequest request)
    {
        throw new NotImplementedException();
    }
}