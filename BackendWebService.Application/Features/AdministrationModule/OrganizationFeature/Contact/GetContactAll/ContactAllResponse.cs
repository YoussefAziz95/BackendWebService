using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record ContactAllResponse(
int OrganizationId,
string? Value,
string? Type,
ContactEnum? ContactType) : IConvertibleFromEntity<Contact, ContactAllResponse>
{
    public static ContactAllResponse FromEntity(Contact Contact) =>
    new ContactAllResponse(
    Contact.OrganizationId,
    Contact.Value,
    Contact.Type,
    Contact.ContactType
    );
}
