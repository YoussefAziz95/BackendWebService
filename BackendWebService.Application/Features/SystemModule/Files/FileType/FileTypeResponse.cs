using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record FileTypeResponse(
FileTypeEnum Type,
string Extentions,
List<FileLogResponse> FileLogs,
List<FileFieldValidatorResponse> Validators):IConvertibleFromEntity<FileType, FileTypeResponse>
{
public static FileTypeResponse FromEntity(FileType FileType) =>
new FileTypeResponse(
FileType.Type,
FileType.Extentions,
FileType.FileLogs.Select(FileLogResponse.FromEntity).ToList(),
FileType.Validators.Select(FileFieldValidatorResponse.FromEntity).ToList());
}