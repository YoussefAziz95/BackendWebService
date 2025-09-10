using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PreDocumentResponse(
string Name,
bool? IsRequired,
bool? IsMultiple,
bool? IsLocal,
int FileTypeId) : IConvertibleFromEntity<PreDocument, PreDocumentResponse>
{
    public static PreDocumentResponse FromEntity(PreDocument PreDocument) =>
    new PreDocumentResponse(
    PreDocument.Name,
    PreDocument.IsRequired,
    PreDocument.IsMultiple,
    PreDocument.IsLocal,
    PreDocument.FileTypeId);
}
