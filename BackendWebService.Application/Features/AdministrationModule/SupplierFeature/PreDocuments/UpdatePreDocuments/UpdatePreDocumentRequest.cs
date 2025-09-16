using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdatePreDocumentRequest(
string Name,
bool IsRequired,
bool IsMultiple,
bool IsLocal,
int FileTypeId) : IConvertibleToEntity<PreDocument>,IRequest<int>
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