namespace Application.Features;

public record CategoryWithFileResponse(
int? Id,
string Name,
int? ParentId,
string? FileLink,
bool? IsActive);
