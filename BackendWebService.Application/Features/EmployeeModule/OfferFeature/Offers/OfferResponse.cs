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
List<AddCriteriaRequest> Criterias,
List<AddOfferItemRequest> OfferItems,
List<AddOfferObjectRequest> OfferObjects);


