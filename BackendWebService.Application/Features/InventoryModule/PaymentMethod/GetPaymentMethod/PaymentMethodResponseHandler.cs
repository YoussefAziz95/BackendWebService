using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class PaymentMethodResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PaymentMethodRequest, PaymentMethodResponse>
{
 
    public IResponse<PaymentMethodResponse> Handle(PaymentMethodRequest request)
    {
        var entity = unitOfWork.GenericRepository<PaymentMethod>().Get();

        var result = PaymentMethodResponse.FromEntity(entity);

        return Success(result);
    }
}