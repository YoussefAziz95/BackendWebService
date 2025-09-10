namespace BackendWebService.Application.Features.ClientModule.Deals.GetOfferDealDetails;

public record GetOfferDealDetailsResponse(
int OfferItemId,
string OfferItemName,
int OfferItemQuantity);