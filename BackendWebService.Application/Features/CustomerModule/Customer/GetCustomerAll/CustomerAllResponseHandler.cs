using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CustomerAllResponseHandler : ResponseHandler, IRequestHandler<CustomerAllRequest, List<CustomerAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<CustomerAllResponse>> Handle(CustomerAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Customer>().GetAll();

        var result = entity.Select(CustomerAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

