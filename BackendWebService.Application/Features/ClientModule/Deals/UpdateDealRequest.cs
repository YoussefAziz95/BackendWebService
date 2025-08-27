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
List<UpdateDealDetailsRequest> DealDetails);
