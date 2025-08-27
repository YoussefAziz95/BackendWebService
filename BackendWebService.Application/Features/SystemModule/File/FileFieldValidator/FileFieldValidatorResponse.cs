using Domain.Enums;

namespace Application.Features;
public record FileFieldValidatorResponse(
int FileTypeId,
FileType FileType,
ValidatorEnum Validator);