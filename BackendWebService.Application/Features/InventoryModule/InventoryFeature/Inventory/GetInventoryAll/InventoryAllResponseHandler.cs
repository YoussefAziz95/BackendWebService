using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class InventoryAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<InventoryAllRequest, List<InventoryAllResponse>>
{
    public IResponse<List<InventoryAllResponse>> Handle(InventoryAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Inventory>().GetAll();

        var result = entity.Select(InventoryAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

