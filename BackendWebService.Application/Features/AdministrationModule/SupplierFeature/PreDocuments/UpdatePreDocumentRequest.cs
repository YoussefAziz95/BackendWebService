using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdatePreDocumentRequest([property: Required] int Id, string? Name, int FileTypeId, bool? IsRequired, bool? IsMultiple, bool? IsLocal);