using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientPropertyAllRequest(
int CustomerId,
int PropertyId,
int AddressId,
string? Description,
string? City,
string? State,
string? PostalCode,
string? Country,
bool IsActive,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ClientPropertyAllResponse>>
{
    public IValidator<ClientPropertyAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientPropertyAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

