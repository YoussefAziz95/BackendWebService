using Application.Profiles;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features;
public record UpdateFileTypeRequest(FileTypeEnum Type,
string Extentions,
List<UpdateFileLogRequest> FileLogs,
List<UpdateFileFieldValidatorRequest> Validators):IConvertibleToEntity<FileType>
{
public FileType ToEntity() => new FileType
{
Type = Type,
Extentions = Extentions,
FileLogs = FileLogs.Select(x => x.ToEntity()).ToList(),
Validators = Validators.Select(x => x.ToEntity()).ToList(),
};
}