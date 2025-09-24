using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
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
List<UpdateOfferObjectRequest> OfferObjects) : IConvertibleToEntity<Offer>, IRequest<int>
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
        Criterias = Criterias.Select(x => x.ToEntity()).ToList(),
        OfferItems = OfferItems.Select(x => x.ToEntity()).ToList(),
        OfferObjects = OfferObjects.Select(x => x.ToEntity()).ToList(),

    };
}


