using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record DealAllResponse(
int OrganizationId,
int OfferId,
int? UserId,
int CompanyVendorId,
int? Vat,
int? Quantity,
int? Discount,
int? StatusId,
decimal? TotalPrice,
decimal? FinalPrice) : IConvertibleFromEntity<Deal, DealAllResponse>
{
    public static DealAllResponse FromEntity(Deal Deal) =>
    new DealAllResponse(
    Deal.OrganizationId,
    Deal.OfferId,
    Deal.UserId,
    Deal.CompanyVendorId,
    Deal.Vat,
    Deal.Quantity,
    Deal.Discount,
    Deal.StatusId,
    Deal.TotalPrice,
    Deal.FinalPrice);
}

