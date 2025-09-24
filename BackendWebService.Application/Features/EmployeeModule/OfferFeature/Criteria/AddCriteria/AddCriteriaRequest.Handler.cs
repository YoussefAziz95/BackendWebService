using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddCriteriaRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCriteriaRequest, int>
{
    public IResponse<int> Handle(AddCriteriaRequest request)
    {
        var criteria = new Criteria
        {
            Term = request.Term,
            FileTypeId = request.FileTypeId,
            IsRequired = request.IsRequired,
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