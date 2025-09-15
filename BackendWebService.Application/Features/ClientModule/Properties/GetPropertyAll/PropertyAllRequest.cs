using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PropertyAllRequest(
int UserId,
string Name,
string? ContactName,
string ContactNumber,
int? ZoneId,
double Latitude,
double Longitude,
DateTimeOffset CreatedAt,
DateTimeOffset? DeletedAt,
bool IsDeleted,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PropertyAllResponse>>
{
    public IValidator<PropertyAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PropertyAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

