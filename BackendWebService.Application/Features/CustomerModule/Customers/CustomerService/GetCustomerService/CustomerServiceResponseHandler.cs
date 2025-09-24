using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CustomerServiceResponseHandler : ResponseHandler, IRequestHandler<CustomerServiceRequest, CustomerServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerServiceResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CustomerServiceResponse> Handle(CustomerServiceRequest request)
    {
        var entity = _unitOfWork.GenericRepository<CustomerService>().Get();

        var result = CustomerServiceResponse.FromEntity(entity);

        return Success(result);
    }
}

