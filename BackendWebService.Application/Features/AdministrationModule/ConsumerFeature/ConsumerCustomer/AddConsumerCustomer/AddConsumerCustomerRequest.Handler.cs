using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddConsumerCustomerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddConsumerCustomerRequest, int>
{
    public IResponse<int> Handle(AddConsumerCustomerRequest request)
    {
        throw new NotImplementedException();
    }
}