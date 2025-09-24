using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePaymentMethodRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePaymentMethodRequest, int>
{
    public IResponse<int> Handle(UpdatePaymentMethodRequest request)
    {
        throw new NotImplementedException();
    }
}