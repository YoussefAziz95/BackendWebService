using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AddressRequest(
int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City) : IRequest<AddressResponse>
{
    public IValidator<AddressRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddressRequest> validator)
    {
        throw new NotImplementedException();
    }
}

