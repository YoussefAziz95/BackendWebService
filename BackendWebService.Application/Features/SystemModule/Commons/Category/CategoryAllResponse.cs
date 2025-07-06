namespace Application.Features;
public record CategoryAllResponse(
int? Id,
string Name,
int? ParentId,
string? FileLink,
bool? HasChild,
bool? IsActive);
