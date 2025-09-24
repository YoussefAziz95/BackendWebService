using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddInventoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddInventoryRequest, int>
{
    public IResponse<int> Handle(AddInventoryRequest request)
    {
        throw new NotImplementedException();
    }
}