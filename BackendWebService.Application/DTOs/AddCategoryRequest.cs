namespace Application.DTOs;

public record AddCategoryRequest(string Name, int? ParentId, int FileId);
public record CategoryResponse(int? Id, string Name, int? ParentId, FileResponse? File, bool? IsActive);
public record CategoryWithFileResponse(int? Id, string Name, int? ParentId, string? File, bool? IsActive);
public record CategoryHasChildResponse(int? Id, string Name, int? ParentId, FileResponse? File, bool? HasChild, bool? IsActive);
public record UpdateCategoryRequest(int Id, string Name, int? ParentId, int FileId);
