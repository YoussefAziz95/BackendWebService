using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddFileFieldValidatorRequest(
int FileTypeId,
AddFileTypeRequest FileType,
ValidatorEnum Validator):IConvertibleToEntity<FileFieldValidator>
{
public FileFieldValidator ToEntity() => new FileFieldValidator
{
FileTypeId = FileTypeId,
FileType = FileType.ToEntity(),
Validator = Validator};
}