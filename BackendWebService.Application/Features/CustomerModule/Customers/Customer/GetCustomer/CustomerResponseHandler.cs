using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class CustomerResponseHandler : ResponseHandler, IRequestByIdHandler<CustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CustomerResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Customer>().GetById(id);

        var result = CustomerResponse.FromEntity(entity);

        return Success(result);
    }
}

