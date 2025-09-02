using Domain.Enums;

namespace Application.Features;
public record ServiceAllResponse(
string Name,
string Description,
string Code,
int CategoryId);

