namespace Application.Features;
public record ZoneResponse(int? Id, string Name, string? Description, int? ParentId, bool? IsActive);