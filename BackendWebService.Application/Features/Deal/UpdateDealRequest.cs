namespace Application.Features;

public record UpdateDealRequest(
int Id,
int OfferId,
decimal? TotalPrice,
decimal? FinalPrice,
int? Vat,
int? Discount,
int? Quantity,
int? UserId,
int StatusId,
List<UpdateDealDocumentRequest> DealDocuments,
List<UpdateDealDetailsRequest> DealDetails);
