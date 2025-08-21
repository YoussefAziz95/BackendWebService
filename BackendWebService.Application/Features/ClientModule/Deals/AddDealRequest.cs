using Application.Features;

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
List<AddDealDetailsRequest> DealDetails
    );
