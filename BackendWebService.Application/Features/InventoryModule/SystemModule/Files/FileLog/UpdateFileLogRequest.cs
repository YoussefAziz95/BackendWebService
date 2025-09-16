using Application.Profiles;

namespace Application.Features;
public record UpdateFileLogRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
UpdateFileTypeRequest FileType):IConvertibleToEntity<FileLog>
{
public FileLog ToEntity() => new FileLog
{
FileName = FileName,
FullPath = FullPath,
Extention = Extention,
FileTypeId = FileTypeId,
FileType = FileType.ToEntity()
};
}