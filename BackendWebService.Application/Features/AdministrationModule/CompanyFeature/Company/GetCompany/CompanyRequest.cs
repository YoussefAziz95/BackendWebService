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
    public IValidator<CompanyRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CompanyRequest> validator)
    {
        throw new NotImplementedException();
    }
}

