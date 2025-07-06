using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddCriteriaCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCriteriaCommand, int>
{
    public IResponse<int> Handle(AddCriteriaCommand request)
    {
        var criteria = new Criteria
        {
            Term = request.Term,
            FileTypeId = request.FileTypeId,
            IsRequired = request.IsRequired ?? false,
            Weight = request.Weight,
            OfferId = request.OfferId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Criteria>().Add(criteria);
        unitOfWork.CommitAsync();

        return Success(criteria.Id);
    }
}
