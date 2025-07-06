using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddOrganizationCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOrganizationCommand, int>
{
    public IResponse<int> Handle(AddOrganizationCommand request)
    {
        var organization = new Organization
        {
            Name = request.Name,
            Country = request.Country,
            City = request.City,
            StreetAddress = request.StreetAddress,
            Type = request.Type,
            FaxNo = request.FaxNo,
            Phone = request.Phone,
            Email = request.Email,
            TaxNo = request.TaxNo,
            FileId = request.FileId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Organization>().Add(organization);
        unitOfWork.CommitAsync();

        return Success(organization.Id);
    }
}
