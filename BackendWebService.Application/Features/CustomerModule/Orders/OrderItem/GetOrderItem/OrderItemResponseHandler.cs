using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class OrderItemResponseHandler : ResponseHandler, IRequestByIdHandler<OrderItemResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderItemResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<OrderItemResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<OrderItem>().GetById(id);

        var result = OrderItemResponse.FromEntity(entity);

        return Success(result);
    }
}

