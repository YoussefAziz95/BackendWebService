namespace Application.DTOs;

public record AddZoneRequest(string Name, string? Description, int? ParentId);

public record ZoneResponse(
    int? Id,
    string Name,
    string? Description,
    int? ParentId,
    bool? IsActive
);

public record UpdateZoneRequest(int Id, string Name, string? Description, int? ParentId);
