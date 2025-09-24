using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddOrderRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOrderRequest, int>
{
    public IResponse<int> Handle(AddOrderRequest request)
    {
        throw new NotImplementedException();
    }
}