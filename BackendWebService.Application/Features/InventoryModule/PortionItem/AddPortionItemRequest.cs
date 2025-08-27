using Domain;

namespace Application.Features;
public record AddPortionItemRequest(
int PortionId,
 int ItemId,
Portion Portion);