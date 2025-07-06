using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddCompanyCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCompanyCommand, int>
{
    public IResponse<int> Handle(AddCompanyCommand request)
    {
        var company = new Company
        {
            CompanyName = request.CompanyName,
            RegistrationNumber = request.RegistrationNumber,
            ContactEmail = request.Email,
            ContactPhone = request.Phone,
            Status = Domain.Enums.StatusEnum.Active,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Company>().Add(company);
        unitOfWork.CommitAsync();

        // Add Addresses if provided
        if (request.Addresses is not null)
        {
            foreach (var address in request.Addresses)
            {
                var addressEntity = new Address
                {
                    FullAddress = address.FullAddress,
                    Street = address.Street,
                    Zone = address.Zone,
                    State = address.State,
                    City = address.City,
                    IsAdministration = address.IsAdministration,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "System",
                    IsActive = true,
                    IsDeleted = false,
                    IsSystem = true
                };
                unitOfWork.GenericRepository<Address>().Add(addressEntity);
            }
        }

        // Add Contacts if provided
        if (request.Contacts is not null)
        {
            foreach (var contact in request.Contacts)
            {
                var contactEntity = new Contact
                {
                    CompanyId = company.Id,
                    Type = contact.Type,
                    Value = contact.Value,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "System",
                    IsActive = true,
                    IsDeleted = false,
                    IsSystem = true
                };
                unitOfWork.GenericRepository<Contact>().Add(contactEntity);
            }
        }

        unitOfWork.CommitAsync();

        return Success(company.Id);
    }
}
