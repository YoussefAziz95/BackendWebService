using Application.Profiles;
using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateCompanyRequest(
int Id,
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
List<UpdateCompanyCategoryRequest> Category,
List<UpdateManagerRequest> Manager): IConvertibleToEntity<Company>

{
    public Company ToEntity() => new Company
    {
        Id = Id,
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
