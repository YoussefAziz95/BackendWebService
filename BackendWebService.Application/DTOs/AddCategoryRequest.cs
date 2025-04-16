namespace Application.DTOs;

public record AddCategoryRequest(string Name, int? ParentId);
public record CategoryResponse(int? Id, string Name, int? ParentId, bool? IsActive);
public record UpdateCategoryRequest(int Id, string Name, int? ParentId);
