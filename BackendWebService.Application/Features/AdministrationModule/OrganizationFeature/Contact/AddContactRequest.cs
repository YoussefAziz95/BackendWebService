using Application.Profiles;
using Domain;
using Domain.Enums;
using Org.BouncyCastle.Asn1.Cms;

namespace Application.Features;
public record AddContactRequest(
int OrganizationId,
string? Value,
string? Type,
ContactEnum? ContactType):IConvertibleToEntity<Contact>
{
public Contact ToEntity() => new Contact
{

OrganizationId = OrganizationId,
Value = Value,
Type = Type,
ContactType = ContactType
};
}
