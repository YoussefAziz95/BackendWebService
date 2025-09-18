using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddPaymentMethodRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPaymentMethodRequest, int>
{
    public IResponse<int> Handle(AddPaymentMethodRequest request)
    {
        throw new NotImplementedException();
    }
}