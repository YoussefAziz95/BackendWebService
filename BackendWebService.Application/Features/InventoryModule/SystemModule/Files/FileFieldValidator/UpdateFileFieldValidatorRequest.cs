using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record UpdateFileFieldValidatorRequest(
int FileTypeId,
UpdateFileTypeRequest FileType,
ValidatorEnum Validator):IConvertibleToEntity<FileFieldValidator>
{
public FileFieldValidator ToEntity() => new FileFieldValidator
{
FileTypeId = FileTypeId,
FileType = FileType.ToEntity(),
Validator = Validator
};
}