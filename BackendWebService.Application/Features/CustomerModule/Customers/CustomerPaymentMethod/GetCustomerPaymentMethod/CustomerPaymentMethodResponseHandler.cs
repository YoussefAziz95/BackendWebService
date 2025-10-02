using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CustomerPaymentMethodResponseHandler : ResponseHandler, IRequestByIdHandler<CustomerPaymentMethodResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerPaymentMethodResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CustomerPaymentMethodResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<CustomerPaymentMethod>().GetById(id);

        var result = CustomerPaymentMethodResponse.FromEntity(entity);

        return Success(result);
    }
}

