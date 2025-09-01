using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record AddPreDocumentRequest(
string Name,
bool IsRequired,
bool IsMultiple,
bool IsLocal,
int FileTypeId):IConvertibleToEntity<PreDocument>
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