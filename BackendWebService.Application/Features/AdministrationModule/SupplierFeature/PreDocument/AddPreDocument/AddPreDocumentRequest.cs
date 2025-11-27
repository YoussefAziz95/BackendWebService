using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddPreDocumentRequest(
string Name,
bool IsRequired,
bool IsMultiple,
bool IsLocal,
int FileTypeId) : IConvertibleToEntity<PreDocument>, IRequest<int>
{
    public PreDocument ToEntity() => new PreDocument
    {
        Name = Name,
        IsRequired = IsRequired,
        IsMultiple = IsMultiple,
        IsLocal = IsLocal,
        FileTypeId = FileTypeId
    };
}
