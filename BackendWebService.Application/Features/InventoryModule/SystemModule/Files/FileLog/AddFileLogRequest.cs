using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddFileLogRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
AddFileTypeRequest FileType):IConvertibleToEntity<FileLog>
{
public FileLog ToEntity() => new FileLog
{
FileName = FileName,
FullPath = FullPath,
Extention = Extention,
FileTypeId= FileTypeId,
FileType= FileType.ToEntity()
};
}