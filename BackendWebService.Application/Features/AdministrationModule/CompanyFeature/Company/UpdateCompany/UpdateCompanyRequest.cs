using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;
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
List<UpdateCompanyCategoryRequest> CompanyCategories,
List<UpdateManagerRequest> Managers) : IConvertibleToEntity<Company>, IRequest<int>
{
    public IValidator<AddManagerRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddManagerRequest> validator)
    {
        throw new NotImplementedException();
    }
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
        CompanyCategories = CompanyCategories.Select(x => x.ToEntity()).ToList(),
        Managers = Managers.Select(x => x.ToEntity()).ToList()
    };

}
