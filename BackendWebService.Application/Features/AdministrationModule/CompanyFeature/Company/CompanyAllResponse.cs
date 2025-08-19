namespace Application.Features;

public record CompanyAllResponse(
int? Id,
string? Name,
string? FullAddress,
string? Zone,
string? Type);