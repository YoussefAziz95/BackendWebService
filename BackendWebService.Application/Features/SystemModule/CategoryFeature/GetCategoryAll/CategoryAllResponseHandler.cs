using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CategoryAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CategoryAllRequest, List<CategoryAllResponse>>
{
    public IResponse<List<CategoryAllResponse>> Handle(CategoryAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Category>().GetAll();

        var result = entity.Select(CategoryAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

