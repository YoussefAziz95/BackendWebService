using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OrderAllResponseHandler : ResponseHandler, IRequestHandler<OrderAllRequest, List<OrderAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<OrderAllResponse>> Handle(OrderAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Order>().GetAll();

        var result = entity.Select(OrderAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

