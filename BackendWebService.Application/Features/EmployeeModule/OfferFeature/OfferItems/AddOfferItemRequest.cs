namespace Application.Features;
public record AddOfferItemRequest(
    int Quantity,
    int? RequiredAmount,
    int ServiceId,
    int OfferId);

