namespace Application.Features;
public record AddZoneRequest(string Name, string? Description, int? ParentId);