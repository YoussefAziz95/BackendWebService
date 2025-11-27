using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CustomerServiceResponseHandler : ResponseHandler, IRequestByIdHandler<CustomerServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerServiceResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CustomerServiceResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<CustomerService>().GetById(id);

        var result = CustomerServiceResponse.FromEntity(entity);

        return Success(result);
    }
}

