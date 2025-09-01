using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ContactResponse(
int OrganizationId,
string? Value,
string? Type,
ContactEnum? ContactType) : IConvertibleFromEntity<Contact, ContactResponse>
{
    public static ContactResponse FromEntity(Contact Contact) =>
    new ContactResponse(
    Contact.OrganizationId,
    Contact.Value,
    Contact.Type,
    Contact.ContactType
    );
}
