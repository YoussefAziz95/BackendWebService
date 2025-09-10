using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientPropertyRequest(
int CustomerId,
int PropertyId,
int AddressId,
string? Description,
string? City,
string? State,
string? PostalCode,
string? Country,
bool IsActive) : IRequest<ClientPropertyResponse>
{
public IValidator<ClientPropertyRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientPropertyRequest> validator)
{
throw new NotImplementedException();
}
}

