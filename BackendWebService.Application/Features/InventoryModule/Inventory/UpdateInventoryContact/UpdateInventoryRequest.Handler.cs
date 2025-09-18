using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateInventoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateInventoryRequest, int>
{
    public IResponse<int> Handle(UpdateInventoryRequest request)
    {
        throw new NotImplementedException();
    }
}