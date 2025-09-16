using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddOrderItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOrderItemRequest, int>
{
    public IResponse<int> Handle(AddOrderItemRequest request)
    {
        throw new NotImplementedException();
    }
}