namespace Application.Features;

public record DealResponse(
int Id,
decimal? TotalPrice,
decimal? FinalPrice,
int? Quantity,
int? Vat,
int? Discount,
int OfferId,
int CompanyVendorId,
int StatusId,
List<DealDocumentResponse> DealDocuments,
List<DealDetailsResponse> DealDetails);
