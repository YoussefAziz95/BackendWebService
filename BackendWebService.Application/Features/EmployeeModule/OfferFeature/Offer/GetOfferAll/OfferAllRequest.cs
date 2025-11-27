using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OfferAllRequest(
int OrganizationId,
string Name,
string? Description,
DateTime StartDate,
DateTime EndDate,
string? Extention,
string Code,
bool IsMultiple,
bool IsLocal,
AccessEnum AccessType,
CurrencyEnum Currency,
int StatusId,
int CompanyId,
int CustomerId,
int SpecificationsFileId,
string? RichText,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<OfferAllResponse>>
{
    public IValidator<OfferAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OfferAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

