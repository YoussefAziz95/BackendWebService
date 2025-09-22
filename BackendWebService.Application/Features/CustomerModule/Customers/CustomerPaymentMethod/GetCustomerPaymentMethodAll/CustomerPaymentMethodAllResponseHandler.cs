using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CustomerPaymentMethodAllResponseHandler : ResponseHandler, IRequestHandler<CustomerPaymentMethodAllRequest, List<CustomerPaymentMethodAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerPaymentMethodAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<CustomerPaymentMethodAllResponse>> Handle(CustomerPaymentMethodAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<CustomerPaymentMethod>().GetAll();

        var result = entity.Select(CustomerPaymentMethodAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

