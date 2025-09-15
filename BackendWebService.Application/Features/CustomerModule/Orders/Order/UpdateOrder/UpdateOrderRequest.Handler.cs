using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateOrderRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateOrderRequest, int>
{
    public IResponse<int> Handle(UpdateOrderRequest request)
    {
        throw new NotImplementedException();
    }
}