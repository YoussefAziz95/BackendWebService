using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record FileLogAllResponse(
string FileName,
string FullPath,
string Extention,
int FileTypeId) : IConvertibleFromEntity<FileLog, FileLogAllResponse>
{
    public static FileLogAllResponse FromEntity(FileLog FileLog) =>
    new FileLogAllResponse(
    FileLog.FileName,
    FileLog.FullPath,
    FileLog.Extention,
    FileLog.FileTypeId);
}

