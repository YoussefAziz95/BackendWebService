namespace Application.Features;
public record UpdateServiceRequest(
string Name,
string Description,
string Code,
int CategoryId);