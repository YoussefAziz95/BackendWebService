using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record FileFieldValidatorResponse(
int FileTypeId,
FileTypeResponse FileType,
ValidatorEnum Validator):IConvertibleFromEntity<FileFieldValidator, FileFieldValidatorResponse>
{
public static FileFieldValidatorResponse FromEntity(FileFieldValidator FileFieldValidator) =>
new FileFieldValidatorResponse(
FileFieldValidator.FileTypeId,
FileFieldValidator.Validator,
FileFieldValidator.FileType.ToEntity(),
FileFieldValidator.Validator
);
}
