namespace Application.Features;
public record PreDocumentResponse(
     string Name,
    bool IsRequired,
    bool IsMultiple,
    bool IsLocal,
    int FileTypeId
    );