using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

internal class ItemAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ItemAllRequest, List<ItemAllResponse>>
{
    public IResponse<List<ItemAllResponse>> Handle(ItemAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Item>().GetAll();

        var result = entity.Select(ItemAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

