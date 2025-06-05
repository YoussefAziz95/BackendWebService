namespace Application.Features;

public record AddCategoryRequest(string Name, int? ParentId, int FileId);
