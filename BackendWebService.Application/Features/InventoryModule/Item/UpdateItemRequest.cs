namespace Application.Features;
public record UpdateItemRequest(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes,
List<UpdatePortionItemRequest> PortionItems);