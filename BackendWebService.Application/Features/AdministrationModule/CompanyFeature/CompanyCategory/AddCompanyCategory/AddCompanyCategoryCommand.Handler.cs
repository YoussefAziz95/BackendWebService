using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddCompanyCategoryCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCompanyCategoryCommand, int>
{
    public IResponse<int> Handle(AddCompanyCategoryCommand request)
    {
        var entity = new CompanyCategory
        {
            CompanyId = request.CompanyId,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<CompanyCategory>().Add(entity);
        unitOfWork.CommitAsync();

        return Success(entity.Id);
    }
}
