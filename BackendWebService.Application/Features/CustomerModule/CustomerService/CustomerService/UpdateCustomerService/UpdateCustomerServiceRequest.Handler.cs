using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCustomerServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCustomerServiceRequest, int>
{
    public IResponse<int> Handle(UpdateCustomerServiceRequest request)
    {
        throw new NotImplementedException();
    }
}