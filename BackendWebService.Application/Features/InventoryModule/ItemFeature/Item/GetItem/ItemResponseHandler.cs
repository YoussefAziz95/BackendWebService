using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class ItemResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ItemResponse>
{

    public IResponse<ItemResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Item>().GetById(id);

        var result = ItemResponse.FromEntity(entity);

        return Success(result);
    }
}