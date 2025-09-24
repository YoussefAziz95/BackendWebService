using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class CategoryResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CategoryRequest, CategoryResponse>
{
 
    public IResponse<CategoryResponse> Handle(CategoryRequest request)
    {
        var entity = unitOfWork.GenericRepository<Category>().Get();

        var result = CategoryResponse.FromEntity(entity);

        return Success(result);
    }
}