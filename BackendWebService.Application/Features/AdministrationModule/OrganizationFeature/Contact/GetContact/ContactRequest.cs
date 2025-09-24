using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ContactRequest(
int OrganizationId,
string? Value,
string? Type) : IRequest<ContactResponse>
{
    public IValidator<ContactRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ContactRequest> validator)
    {
        throw new NotImplementedException();
    }
}

