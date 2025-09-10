using Application.Profiles;
using Domain;

namespace Application.Features;

public record DealResponse(
int OrganizationId,
int OfferId,
int? UserId,
int CompanyVendorId,
int? Vat,
int? Quantity,
int? Discount,
int? StatusId,
decimal? TotalPrice,
decimal? FinalPrice,
List<DealDocumentResponse>? DealDocuments,
List<DealDetailsResponse>? DealDetails):IConvertibleFromEntity<Deal, DealResponse>        
{
public static DealResponse FromEntity(Deal Deal) =>
new DealResponse(
Deal.OrganizationId,
Deal.OfferId,
Deal.UserId,
Deal.CompanyVendorId,
Deal.Vat,
Deal.Quantity,
Deal.Discount,
Deal.StatusId,
Deal.TotalPrice,
Deal.FinalPrice,
Deal.DealDocuments.Select(DealDocumentResponse.FromEntity).ToList(),
Deal.DealDetails.Select(DealDetailsResponse.FromEntity).ToList());
}
