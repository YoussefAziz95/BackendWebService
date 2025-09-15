using Application.Profiles;

namespace Application.Features;
public record FileLogResponse(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
FileTypeResponse FileType):IConvertibleFromEntity<FileLog, FileLogResponse>
{
public static FileLogResponse FromEntity(FileLog FileLog) =>
new FileLogResponse(
FileLog.FileName,
FileLog.FullPath,
FileLog.Extention,
FileLog.FileTypeId,
FileTypeResponse.FromEntity(FileLog.FileType));
}