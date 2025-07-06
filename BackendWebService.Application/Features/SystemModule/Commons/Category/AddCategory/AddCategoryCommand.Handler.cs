using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddCategoryCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCategoryCommand, int>
{
    public IResponse<int> Handle(AddCategoryCommand request)
    {
        var category = new Category
        {
            Name = request.Name,
            ParentId = request.ParentId,
            FileId = request.FileId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Category>().Add(category);
        unitOfWork.CommitAsync();

        return Success(category.Id);
    }
}
