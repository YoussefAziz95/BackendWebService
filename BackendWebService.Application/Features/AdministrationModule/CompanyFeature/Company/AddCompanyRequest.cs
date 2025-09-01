using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddCompanyRequest(
int OrganizationId,
string? CompanyName,
string? RegistrationNumber,
string? ContactEmail,
string? ContactPhone,
string? Chairman,
string? QualityCertificates,
string? ViceChairman,
string? ProductType,
StatusEnum Status,
List<AddCompanyCategoryRequest> Category,
List<AddManagerRequest> Manager) : IConvertibleToEntity<Company>
{
public Company ToEntity() => new Company
{
OrganizationId = OrganizationId,
CompanyName = CompanyName,
RegistrationNumber = RegistrationNumber,
ContactEmail = ContactEmail,
ContactPhone = ContactPhone,
Chairman = Chairman,
QualityCertificates = QualityCertificates,
ViceChairman = ViceChairman,
ProductType = ProductType,
Status = Status,
Manager = Manager.Select(x => x.ToEntity()).ToList()
};
}

