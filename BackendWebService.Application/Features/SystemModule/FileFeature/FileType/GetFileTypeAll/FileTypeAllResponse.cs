using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record FileTypeAllResponse(
FileTypeEnum Type,
string Extentions) : IConvertibleFromEntity<FileType, FileTypeAllResponse>
{
    public static FileTypeAllResponse FromEntity(FileType FileType) =>
    new FileTypeAllResponse(
    FileType.Type,
    FileType.Extentions);
}

