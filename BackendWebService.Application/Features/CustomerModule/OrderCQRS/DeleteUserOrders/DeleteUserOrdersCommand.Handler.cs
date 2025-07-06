using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DeleteUserOrdersCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<DeleteUserOrdersCommand, bool>
{
    public IResponse<bool> Handle(DeleteUserOrdersCommand request)
    {
        var order = unitOfWork.GenericRepository<Order>().Get(o => o.UserId == request.UserId);
        if (order is null)
            return NotFound<bool>("No orders found for the specified user.");
        unitOfWork.BeginTransactionAsync();
        unitOfWork.GenericRepository<Order>().Delete(order);
        if (unitOfWork.SaveAsync().Result <= 0)
            return BadRequest<bool>("Something went wrong while deleting the orders.");
        unitOfWork.CommitAsync();
        return Success(true);
    }
}