namespace Application.Features;

public record AddDealDetailsRequest(
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
int OfferItemId);