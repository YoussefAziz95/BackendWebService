using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record FileFieldValidatorResponse(
int FileTypeId,
FileTypeResponse FileType,
ValidatorEnum Validator) : IConvertibleFromEntity<FileFieldValidator, FileFieldValidatorResponse>
{
    public static FileFieldValidatorResponse FromEntity(FileFieldValidator FileFieldValidator) =>
    new FileFieldValidatorResponse(
    FileFieldValidator.FileTypeId,
    FileTypeResponse.FromEntity(FileFieldValidator.FileType),
    FileFieldValidator.Validator
    );
}
