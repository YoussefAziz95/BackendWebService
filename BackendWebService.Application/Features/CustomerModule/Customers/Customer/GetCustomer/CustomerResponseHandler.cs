using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class CustomerResponseHandler : ResponseHandler, IRequestHandler<CustomerRequest, CustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CustomerResponse> Handle(CustomerRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Customer>().Get();

        var result = CustomerResponse.FromEntity(entity);

        return Success(result);
    }
}

