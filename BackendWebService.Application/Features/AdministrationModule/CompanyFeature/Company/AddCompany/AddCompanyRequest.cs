using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

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
List<AddCompanyCategoryRequest> CompanyCategories,
List<AddManagerRequest> Managers) : IConvertibleToEntity<Company>, IRequest<int>
{
    public IValidator<AddCompanyCategoryRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCompanyCategoryRequest> validator)
    {
        throw new NotImplementedException();
    }
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
        CompanyCategories = CompanyCategories.Select(x => x.ToEntity()).ToList(),
        Managers = Managers.Select(x => x.ToEntity()).ToList()
    };

}

