using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AddressAllRequest(
int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<AddressAllResponse>>
{
    public IValidator<AddressAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddressAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

