namespace Application.Features;

public record CategoryResponse(int? Id, string Name, int? ParentId, FileResponse? File, bool? IsActive);
