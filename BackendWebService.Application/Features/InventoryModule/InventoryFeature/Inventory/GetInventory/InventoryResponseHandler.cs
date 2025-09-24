using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

internal class InventoryResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<InventoryRequest, InventoryResponse>
{

    public IResponse<InventoryResponse> Handle(InventoryRequest request)
    {
        var entity = unitOfWork.GenericRepository<Inventory>().Get();

        var result = InventoryResponse.FromEntity(entity);

        return Success(result);
    }
}