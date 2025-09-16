using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateContactRequest(
int OrganizationId,
string? Value,
string? Type,
ContactEnum? ContactType) : IConvertibleToEntity<Contact>, IRequest<int>
{
    public Contact ToEntity() => new Contact
    {
        OrganizationId = OrganizationId,
        Value = Value,
        Type = Type
    };
}

