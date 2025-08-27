namespace Application.Features;
public record AddItemRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
List<AddPortionItemRequest> PortionItems);