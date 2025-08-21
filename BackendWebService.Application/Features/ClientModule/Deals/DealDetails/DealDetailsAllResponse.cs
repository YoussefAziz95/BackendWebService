using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record DealDetailsAllResponse(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice,
Deal Deal,
OfferItem OfferItem
 );
