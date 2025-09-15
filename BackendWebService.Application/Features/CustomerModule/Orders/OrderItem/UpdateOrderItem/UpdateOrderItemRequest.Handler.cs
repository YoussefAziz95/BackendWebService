using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateOrderItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateOrderItemRequest, int>
{
    public IResponse<int> Handle(UpdateOrderItemRequest request)
    {
        throw new NotImplementedException();
    }
}