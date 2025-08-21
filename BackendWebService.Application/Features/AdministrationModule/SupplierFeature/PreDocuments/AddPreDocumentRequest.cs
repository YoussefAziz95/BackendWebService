using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record AddPreDocumentRequest(
    string Name,
    bool IsRequired,
    bool IsMultiple,
    bool IsLocal,
    int FileTypeId
   
    );