using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdatePreDocumentRequest(
    string Name,
    bool IsRequired,
    bool IsMultiple,
    bool IsLocal,
    int FileTypeId
    );