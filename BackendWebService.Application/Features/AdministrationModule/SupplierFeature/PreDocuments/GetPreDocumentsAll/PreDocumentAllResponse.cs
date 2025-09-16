using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record PreDocumentAllResponse(
string Name,
bool? IsRequired,
bool? IsMultiple,
bool? IsLocal,
int FileTypeId) : IConvertibleFromEntity<PreDocument, PreDocumentAllResponse>
{
    public static PreDocumentAllResponse FromEntity(PreDocument PreDocument) =>
    new PreDocumentAllResponse(
    PreDocument.Name,
    PreDocument.IsRequired,
    PreDocument.IsMultiple,
    PreDocument.IsLocal,
    PreDocument.FileTypeId);
}
