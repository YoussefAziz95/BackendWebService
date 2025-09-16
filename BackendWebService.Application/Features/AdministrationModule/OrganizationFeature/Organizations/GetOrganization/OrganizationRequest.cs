using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OrganizationRequest(
string Country,
string City,
string StreetAddress,
OrganizationEnum Type,
string FaxNo,
string Phone,
string Email,
string TaxNo,
int FileId) : IRequest<OrganizationResponse>
{
public IValidator<OrganizationRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OrganizationRequest> validator)
{
throw new NotImplementedException();
}
}

