using Application.DTOs.Common;

namespace Application.DTOs;

public record AddCategoryRequest(string Name, int? ParentId, int FileId);
public record CategoryResponse(int? Id, string Name, int? ParentId, DownloadResponse? File, bool? IsActive);
public record CategoryHasChildResponse(int? Id, string Name, int? ParentId, DownloadResponse? File, bool? HasChild, bool? IsActive);
public record UpdateCategoryRequest(int Id, string Name, int? ParentId, int FileId);
