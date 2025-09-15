using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCustomerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCustomerRequest, int>
{
    public IResponse<int> Handle(UpdateCustomerRequest request)
    {
        throw new NotImplementedException();
    }
}