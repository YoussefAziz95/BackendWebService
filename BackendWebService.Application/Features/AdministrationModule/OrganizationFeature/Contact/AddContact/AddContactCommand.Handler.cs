using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddContactCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddContactCommand, int>
{
    public IResponse<int> Handle(AddContactCommand request)
    {
        var contact = new Contact
        {
            CompanyId = request.CompanyId,
            Value = request.Value,
            Type = request.Type,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Contact>().Add(contact);
        unitOfWork.CommitAsync();

        return Success(contact.Id);
    }
}
