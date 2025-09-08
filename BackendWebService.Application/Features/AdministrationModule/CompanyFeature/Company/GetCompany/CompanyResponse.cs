using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CompanyResponse(
int OrganizationId,
string? CompanyName,
string? RegistrationNumber,
string? ContactEmail,
string? ContactPhone,
string? Chairman,
string? QualityCertificates,
string? ViceChairman,
string? ProductType,
StatusEnum Status) : IConvertibleFromEntity<Company, CompanyResponse>
{
    public static CompanyResponse FromEntity(Company company) =>
    new CompanyResponse(
    company.OrganizationId,
    company.CompanyName,
    company.RegistrationNumber,
    company.ContactEmail,
    company.ContactPhone,
    company.Chairman,
    company.QualityCertificates,
    company.ViceChairman,
    company.ProductType,
    company.Status);
}