using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ProductResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ProductRequest, ProductResponse>
{
 
    public IResponse<ProductResponse> Handle(ProductRequest request)
    {
        var entity = unitOfWork.GenericRepository<Product>().Get();

        var result = ProductResponse.FromEntity(entity);

        return Success(result);
    }
}