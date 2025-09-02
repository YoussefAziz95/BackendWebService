using Application.Profiles;
using Domain;
using Domain.Enums;


namespace Application.Features;
public record OfferResponse(
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
List<CriteriaResponse> Criterias,
List<OfferItemResponse> OfferItems,
List<OfferObjectResponse> OfferObjects) : IConvertibleFromEntity<Offer, OfferResponse>
{
public static OfferResponse FromEntity(Offer Offer) =>
new OfferResponse(
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
Offer.RichText,
Offer.Criterias.Select(CriteriaResponse.FromEntity).ToList(),
Offer.OfferItems.Select(OfferItemResponse.FromEntity).ToList(),
Offer.OfferObjects.Select(OfferObjectResponse.FromEntity).ToList());
}



