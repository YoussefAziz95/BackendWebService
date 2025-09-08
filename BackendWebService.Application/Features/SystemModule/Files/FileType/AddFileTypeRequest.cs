using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddFileTypeRequest(
FileTypeEnum Type,
string Extentions,
List<AddFileLogRequest> FileLogs,
List<AddFileFieldValidatorRequest> Validators):IConvertibleToEntity<FileType>
{
public FileType ToEntity() => new FileType
{
Type = Type,
Extentions = Extentions,
FileLogs = FileLogs.Select(x => x.ToEntity()).ToList(),
Validators = Validators.Select(x => x.ToEntity()).ToList(),
};
}