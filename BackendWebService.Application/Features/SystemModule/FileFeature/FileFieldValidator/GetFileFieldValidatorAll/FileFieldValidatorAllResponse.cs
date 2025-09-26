using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record FileFieldValidatorAllResponse(
int FileTypeId,
ValidatorEnum Validator) : IConvertibleFromEntity<FileFieldValidator, FileFieldValidatorAllResponse>
{
    public static FileFieldValidatorAllResponse FromEntity(FileFieldValidator FileFieldValidator) =>
    new FileFieldValidatorAllResponse(
    FileFieldValidator.FileTypeId,
    FileFieldValidator.Validator);
}

