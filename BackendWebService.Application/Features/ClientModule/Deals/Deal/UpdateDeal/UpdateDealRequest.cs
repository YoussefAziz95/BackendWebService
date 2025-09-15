using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
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
List<UpdateDealDetailsRequest> DealDetails) : IConvertibleToEntity<Deal>,IRequest<int>
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
        DealDocuments = DealDocuments.Select(x => x.ToEntity()).ToList(),
        DealDetails = DealDetails.Select(x => x.ToEntity()).ToList()
    };
}

