using Application.Profiles;
using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record OrganizationAllResponse(
string Country,
string City,
string StreetAddress,
OrganizationEnum Type,
string FaxNo,
string Phone,
string Email,
string TaxNo,
int FileId):IConvertibleFromEntity<Organization, OrganizationAllResponse>
{
public static OrganizationAllResponse FromEntity(Organization Organization) =>
new OrganizationAllResponse(
Organization.Country,
Organization.City,
Organization.StreetAddress,
Organization.Type,
Organization.FaxNo,
Organization.Phone,
Organization.Email,
Organization.TaxNo,
Organization.FileId
);
}
