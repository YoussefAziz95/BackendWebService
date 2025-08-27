using Domain.Enums;

namespace Application.Features;
public record UpdateFileFieldValidatorRequest(
int FileTypeId,
FileType FileType,
ValidatorEnum Validator);