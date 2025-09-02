using Application.Profiles;
using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddOfferRequest(
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
List<AddCriteriaRequest> Criterias,
List<AddOfferItemRequest> OfferItems,
List<AddOfferObjectRequest> OfferObjects):IConvertibleToEntity<Offer>
{
public Offer ToEntity() => new Offer
{
OrganizationId = OrganizationId,
Name = Name,
Description = Description,
StartDate = StartDate,
EndDate = EndDate,
Extention = Extention,
Code = Code,
IsMultiple = IsMultiple,
IsLocal = IsLocal,
AccessType = AccessType,
Currency = Currency,
StatusId = StatusId,
CompanyId = CompanyId,
CustomerId = CustomerId,
SpecificationsFileId = SpecificationsFileId,
RichText = RichText,
Criterias= Criterias.Select(x => x.ToEntity()).ToList(),
OfferItems= OfferItems.Select(x => x.ToEntity()).ToList(),
OfferObjects= OfferObjects.Select(x => x.ToEntity()).ToList(),

};
}





