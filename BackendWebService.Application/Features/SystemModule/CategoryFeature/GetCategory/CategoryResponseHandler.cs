using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CategoryResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<CategoryResponse>
{

    public IResponse<CategoryResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Category>().GetById(id);

        var result = CategoryResponse.FromEntity(entity);

        return Success(result);
    }
}