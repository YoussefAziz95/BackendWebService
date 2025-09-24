using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddItemRequest, int>
{
    public IResponse<int> Handle(AddItemRequest request)
    {
        throw new NotImplementedException();
    }
}