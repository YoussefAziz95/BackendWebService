using Application.Contracts.Features;
using Application.Profiles;
using Application.Features;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateClientPropertyRequest(
int CustomerId,
UpdateClientRequest Customer,
int PropertyId,
UpdatePropertyRequest Property,
int AddressId,
UpdateAddressRequest Address,
string? Description,
string? City,
string? State,
string? PostalCode,
string? Country,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt,
DateTime? DeletedAt) : IConvertibleToEntity<ClientProperty>, IRequest<int>
{
    public ClientProperty ToEntity() => new ClientProperty
    {
        CustomerId = CustomerId,
        Customer = Customer.ToEntity(),
        PropertyId = PropertyId,
        Property = Property.ToEntity(),
        AddressId = AddressId,
        Address = Address.ToEntity(),
        Description = Description,
        City = City,
        State = State,
        PostalCode = PostalCode,
        Country = Country,
        IsActive = IsActive,
        CreatedAt = CreatedAt,
        UpdatedAt = UpdatedAt,
        DeletedAt = DeletedAt
    };
}


