namespace Application.Features;
public record AddServiceRequest(
string Name,
string Description,
string Code,
int CategoryId );