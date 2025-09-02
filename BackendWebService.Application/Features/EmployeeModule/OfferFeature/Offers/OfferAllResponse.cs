using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record OfferAllResponse(
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
string? RichText):IConvertibleFromEntity<Offer, OfferAllResponse>
{
public static OfferAllResponse FromEntity(Offer Offer) =>
new OfferAllResponse(
Offer.OrganizationId,
Offer.Name,
Offer.Description,
Offer.StartDate,
Offer.EndDate,
Offer.Extention,
Offer.Code,
Offer.IsMultiple,
Offer.IsLocal,
Offer.AccessType,
Offer.Currency,
Offer.StatusId,
Offer.CompanyId,
Offer.CustomerId,
Offer.SpecificationsFileId,
Offer.RichText
);
}

