using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class OrderResponseHandler : ResponseHandler, IRequestHandler<OrderRequest, OrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<OrderResponse> Handle(OrderRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Order>().Get();

        var result = OrderResponse.FromEntity(entity);

        return Success(result);
    }
}

