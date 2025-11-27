using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OrderItemAllResponseHandler : ResponseHandler, IRequestHandler<OrderItemAllRequest, List<OrderItemAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderItemAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<OrderItemAllResponse>> Handle(OrderItemAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<OrderItem>().GetAll();

        var result = entity.Select(OrderItemAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

