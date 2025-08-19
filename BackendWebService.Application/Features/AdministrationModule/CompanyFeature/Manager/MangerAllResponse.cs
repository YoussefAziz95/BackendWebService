namespace Application.Features;

public record MangerAllResponse(
int? OrganizationIdd,
string? Name,
string? FullAddress,
string? Zone,
string? Type);