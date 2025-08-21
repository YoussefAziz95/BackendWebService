namespace Application.Features;
public record UpdateOfferItemRequest(
int Quantity,
int? RequiredAmount,
int ServiceId,
int OfferId);

