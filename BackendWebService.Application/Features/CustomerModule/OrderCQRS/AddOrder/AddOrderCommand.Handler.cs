using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AddOrderCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOrderCommand, int>
{
    public IResponse<int> Handle(AddOrderCommand request)
    {
        var user = unitOfWork.GenericRepository<User>().GetById(request.UserId);

        if (user == null)
            return NotFound<int>("User Not Found");

        unitOfWork.BeginTransactionAsync();
        var order = new Order() { UserId = user.Id, OrderName = request.OrderName };
        unitOfWork.GenericRepository<Order>().Add(order);

        var result = unitOfWork.CommitAsync();

        return Success(order.Id);
    }
}