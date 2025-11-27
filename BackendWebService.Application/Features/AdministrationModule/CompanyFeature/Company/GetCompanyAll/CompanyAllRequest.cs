using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CompanyAllRequest(
int OrganizationId,
string? CompanyName,
string? RegistrationNumber,
string? ContactEmail,
string? ContactPhone,
string? Chairman,
string? QualityCertificates,
string? ViceChairman,
string? ProductType,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CompanyAllResponse>>
{
    public IValidator<CompanyAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CompanyAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

