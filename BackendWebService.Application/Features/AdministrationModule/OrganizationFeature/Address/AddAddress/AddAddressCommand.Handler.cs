using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddAddressCommandHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddAddressCommand, int>
{
    public IResponse<int> Handle(AddAddressCommand request)
    {
        var address = new Address
        {
            FullAddress = request.FullAddress,
            Street = request.Street,
            Zone = request.Zone,
            State = request.State,
            City = request.City,
            IsAdministration = request.IsAdministration,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System",
            IsActive = true,
            IsDeleted = false,
            IsSystem = true
        };

        unitOfWork.GenericRepository<Address>().Add(address);
        unitOfWork.CommitAsync();

        return Success(address.Id);
    }
}
