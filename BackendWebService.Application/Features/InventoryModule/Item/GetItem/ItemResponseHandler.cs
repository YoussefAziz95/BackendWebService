using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ItemResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ItemRequest, ItemResponse>
{

    public IResponse<ItemResponse> Handle(ItemRequest request)
    {
        var entity = unitOfWork.GenericRepository<Item>().Get();

        var result = ItemResponse.FromEntity(entity);

        return Success(result);
    }
}