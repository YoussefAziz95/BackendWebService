using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCustomerPaymentMethodRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCustomerPaymentMethodRequest, int>
{
    public IResponse<int> Handle(UpdateCustomerPaymentMethodRequest request)
    {
        throw new NotImplementedException();
    }
}