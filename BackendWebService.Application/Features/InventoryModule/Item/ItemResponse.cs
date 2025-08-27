namespace Application.Features;
public record ItemResponse(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
List<PortionItemResponse> PortionItems);