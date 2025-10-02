using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CustomerServiceAllResponseHandler : ResponseHandler, IRequestHandler<CustomerServiceAllRequest, List<CustomerServiceAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerServiceAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<CustomerServiceAllResponse>> Handle(CustomerServiceAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<CustomerService>().GetAll();

        var result = entity.Select(CustomerServiceAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

