namespace Application.Features;
public record AddOfferObjectRequest(
int OfferId,
int ObjectId,
string ObjectType,
string? Notes);

