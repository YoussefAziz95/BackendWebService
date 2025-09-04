using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CompanyRequest(
int OrganizationId,
string? CompanyName,
string? RegistrationNumber,
string? ContactEmail,
string? ContactPhone,
string? Chairman,
string? QualityCertificates,
string? ViceChairman,
string? ProductType) : IRequest<CompanyResponse>
{
    public IValidator<AddCompanyRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCompanyRequest> validator)
    {
        throw new NotImplementedException();
    }
}

