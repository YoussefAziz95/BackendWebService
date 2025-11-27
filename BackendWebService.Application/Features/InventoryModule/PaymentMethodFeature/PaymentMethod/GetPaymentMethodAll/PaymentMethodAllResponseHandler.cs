using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PaymentMethodAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PaymentMethodAllRequest, List<PaymentMethodAllResponse>>
{
    public IResponse<List<PaymentMethodAllResponse>> Handle(PaymentMethodAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<PaymentMethod>().GetAll();

        var result = entity.Select(PaymentMethodAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

