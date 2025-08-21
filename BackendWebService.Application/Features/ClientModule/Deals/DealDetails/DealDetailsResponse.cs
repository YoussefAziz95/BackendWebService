using Domain;

namespace Application.Features;

public record DealDetailsResponse(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
Deal Deal,
OfferItem OfferItem
    );