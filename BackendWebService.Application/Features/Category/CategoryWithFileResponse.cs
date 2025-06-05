namespace Application.Features;

public record CategoryWithFileResponse(int? Id, string Name, int? ParentId, FileResponse? File, bool? IsActive);
