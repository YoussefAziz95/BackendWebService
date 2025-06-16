namespace Application.Features;

public record OfferDealerResponse(
int Id,
decimal? TotalPrice,
decimal? FinalPrice,
int? Quantity,
int? Vat,
int? Discount,
string VendorName,
List<DealDocumentResponse> DealDocuments,
List<DealDetailsResponse> DealDetails);
