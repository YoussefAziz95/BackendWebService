using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ProductResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ProductResponse>
{

    public IResponse<ProductResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Product>().GetById(id);

        var result = ProductResponse.FromEntity(entity);

        return Success(result);
    }
}