using Application.Features;

public record AddDealRequest(
int OfferId,
decimal? TotalPrice,
decimal? FinalPrice,
int? Vat,
int? Discount,
int? Quantity,
int? UserId,
int StatusId,
List<AddDealDocumentRequest> DealDocuments,
List<AddDealDetailsRequest> DealDetails);
