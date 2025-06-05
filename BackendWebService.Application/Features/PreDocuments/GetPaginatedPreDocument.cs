namespace Application.Features;

public record GetPaginatedPreDocument(int Id, string Name, int FileTypeId, bool? IsRequired, bool? IsMultiple, bool? IsLocal);