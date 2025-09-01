using Application.Profiles;
using Domain;

namespace Application.Features;

public record UpdateDealRequest(
int OrganizationId,
int OfferId,
int UserId,
int CompanyVendorId,
int Vat,
int Quantity,
int Discount,
int StatusId,
decimal? TotalPrice,
decimal? FinalPrice,
List<UpdateDealDocumentRequest> DealDocuments,
List<UpdateDealDetailsRequest> DealDetails):IConvertibleToEntity<Deal>
{
public Deal ToEntity() => new Deal
{
    OrganizationId = OrganizationId,
    OfferId = OfferId,
    UserId = UserId,
    Quantity = Quantity,
    Vat = Vat,
    CompanyVendorId = CompanyVendorId,
    Discount = Discount,
    StatusId = StatusId,
    TotalPrice = TotalPrice,
    FinalPrice = FinalPrice,
    DealDocument = DealDocument.Select(x => x.ToEntity()).ToList(),
    DealDetail = DealDetail.Select(x => x.ToEntity()).ToList()
};
} 

