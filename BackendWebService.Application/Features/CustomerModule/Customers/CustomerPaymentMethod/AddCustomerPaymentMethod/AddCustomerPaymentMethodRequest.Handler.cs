using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddCustomerPaymentMethodRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCustomerPaymentMethodRequest, int>
{
    public IResponse<int> Handle(AddCustomerPaymentMethodRequest request)
    {
        throw new NotImplementedException();
    }
}