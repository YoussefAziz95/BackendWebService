using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateOfferRequest(
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
List<UpdateCriteriaRequest> Criterias,
List<UpdateOfferItemRequest> OfferItems,
List<UpdateOfferObjectRequest> OfferObjects);


