using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ProductAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ProductAllRequest, List<ProductAllResponse>>
{
    public IResponse<List<ProductAllResponse>> Handle(ProductAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Product>().GetAll();

        var result = entity.Select(ProductAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

