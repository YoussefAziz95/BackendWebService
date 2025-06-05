namespace Application.Features;

public record CategoryHasChildResponse(int? Id, string Name, int? ParentId, FileResponse? File, bool? HasChild, bool? IsActive);
