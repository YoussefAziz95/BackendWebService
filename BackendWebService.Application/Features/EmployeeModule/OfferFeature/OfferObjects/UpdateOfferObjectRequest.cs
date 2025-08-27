namespace Application.Features;
public record UpdateOfferObjectRequest(
int OfferId,
int ObjectId,
string ObjectType,
string? Notes);

