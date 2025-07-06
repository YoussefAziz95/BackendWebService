namespace Application.Features;
public record CategoryResponse(
int? Id,
string Name,
int? ParentId,
string? FileLink,
bool? IsActive);