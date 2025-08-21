using Domain;

namespace Application.Features;

public record AddDealDetailsRequest(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
Deal Deal,
OfferItem OfferItem
    );