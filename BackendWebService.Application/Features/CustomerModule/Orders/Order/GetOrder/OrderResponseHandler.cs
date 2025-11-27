using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OrderResponseHandler : ResponseHandler, IRequestByIdHandler<OrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<OrderResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Order>().GetById(id);

        var result = OrderResponse.FromEntity(entity);

        return Success(result);
    }
}

