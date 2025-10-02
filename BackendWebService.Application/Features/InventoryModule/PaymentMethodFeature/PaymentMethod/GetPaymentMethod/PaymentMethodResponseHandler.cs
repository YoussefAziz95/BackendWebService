using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class PaymentMethodResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<PaymentMethodResponse>
{

    public IResponse<PaymentMethodResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<PaymentMethod>().GetById(id);

        var result = PaymentMethodResponse.FromEntity(entity);

        return Success(result);
    }
}