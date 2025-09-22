using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PropertyRequest(
int UserId,
string Name,
string? ContactName,
string ContactNumber,
int? ZoneId,
double Latitude,
double Longitude,
DateTimeOffset CreatedAt,
DateTimeOffset? DeletedAt,
bool IsDeleted) : IRequest<PropertyResponse>
{
public IValidator<PropertyRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PropertyRequest> validator)
{
throw new NotImplementedException();
}
}

