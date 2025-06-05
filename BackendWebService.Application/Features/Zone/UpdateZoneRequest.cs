namespace Application.Features;

public record UpdateZoneRequest(int Id, string Name, string? Description, int? ParentId);