using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateConsumerCustomerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateConsumerCustomerRequest, int>
{
    public IResponse<int> Handle(UpdateConsumerCustomerRequest request)
    {
        throw new NotImplementedException();
    }
}