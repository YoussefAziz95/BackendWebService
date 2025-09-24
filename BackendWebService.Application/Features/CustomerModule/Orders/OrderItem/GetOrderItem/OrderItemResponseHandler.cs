using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class OrderItemResponseHandler : ResponseHandler, IRequestHandler<OrderItemRequest, OrderItemResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderItemResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<OrderItemResponse> Handle(OrderItemRequest request)
    {
        var entity = _unitOfWork.GenericRepository<OrderItem>().Get();

        var result = OrderItemResponse.FromEntity(entity);

        return Success(result);
    }
}

