namespace Application.Features;
public record CategoryHasChildResponse(
int? Id,
 string Name,
 int? ParentId,
string? FileLink,
 bool? HasChild,
 bool? IsActive);
