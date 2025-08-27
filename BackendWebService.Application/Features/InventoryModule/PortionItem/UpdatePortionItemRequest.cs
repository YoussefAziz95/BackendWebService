using Domain;

namespace Application.Features;
public record UpdatePortionItemRequest(
int PortionId,
 int ItemId,
Portion Portion);