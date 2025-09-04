using Domain.Enums;

namespace Application.Features;
public record FileFieldValidatorAllResponse(
int FileTypeId,
FileType FileType,
ValidatorEnum Validator);

