using Application.Features;
using Application.Profiles;
using Domain;

public record AddDealRequest(
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
List<AddDealDocumentRequest> DealDocuments,
List<AddDealDetailsRequest> DealDetails):IConvertibleToEntity<Deal>
{
    public Deal ToEntity() => new Deal
    {
        OrganizationId = OrganizationId,
        OfferId=OfferId,
        UserId=UserId,
        Quantity=Quantity,
        Vat=Vat,
        CompanyVendorId= CompanyVendorId,
        Discount=Discount,
        StatusId=StatusId,
        TotalPrice=TotalPrice,
        FinalPrice= FinalPrice,
        DealDocuments= DealDocuments.Select(x => x.ToEntity()).ToList(),
        DealDetails = DealDetails.Select(x => x.ToEntity()).ToList()
    };
} 
