using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class UpdateUserOrderCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserOrderCommand, bool>
{
    public IResponse<bool> Handle(UpdateUserOrderCommand request)
    {
        var order = unitOfWork.GenericRepository<Order>().Get(o => o.UserId == request.UserId && o.Id == request.OrderId);

        if (order is null)
            return NotFound<bool>("Specified Order not found");

        order.OrderName = request.OrderName;

        unitOfWork.CommitAsync();

        return Success(true);
    }
}