using Domain.Enums;

namespace Application.Features;
public record AddFileFieldValidatorRequest(
int FileTypeId,
FileType FileType,
ValidatorEnum Validator);