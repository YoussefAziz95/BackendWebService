using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class InventoryResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<InventoryResponse>
{

    public IResponse<InventoryResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Inventory>().GetById(id);

        var result = InventoryResponse.FromEntity(entity);

        return Success(result);
    }
}