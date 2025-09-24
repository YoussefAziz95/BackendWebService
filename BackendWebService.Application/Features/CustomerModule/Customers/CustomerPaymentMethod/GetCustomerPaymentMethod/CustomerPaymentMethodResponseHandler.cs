using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CustomerPaymentMethodResponseHandler : ResponseHandler, IRequestHandler<CustomerPaymentMethodRequest, CustomerPaymentMethodResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerPaymentMethodResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CustomerPaymentMethodResponse> Handle(CustomerPaymentMethodRequest request)
    {
        var entity = _unitOfWork.GenericRepository<CustomerPaymentMethod>().Get();

        var result = CustomerPaymentMethodResponse.FromEntity(entity);

        return Success(result);
    }
}

