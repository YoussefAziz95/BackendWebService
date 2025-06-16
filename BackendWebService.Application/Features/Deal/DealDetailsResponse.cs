namespace Application.Features;

public record DealDetailsResponse(
int Id,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
int DealId,
int OfferItemId);