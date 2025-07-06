namespace Application.Features;

public record UpdateDealDetailsRequest(
int Id,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
int OfferItemId);