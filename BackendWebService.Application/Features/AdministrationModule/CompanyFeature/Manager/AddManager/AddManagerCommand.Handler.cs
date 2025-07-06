using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddManagerCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddManagerCommand, int>
{
    public IResponse<int> Handle(AddManagerCommand request)
    {
        var manager = new Manager
        {
            CompanyId = request.CompanyId,
            Name = request.Name,
            Position = request.Position,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Manager>().Add(manager);
        unitOfWork.CommitAsync();

        return Success(manager.Id);
    }
}
