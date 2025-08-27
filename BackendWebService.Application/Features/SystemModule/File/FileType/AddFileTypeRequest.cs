using Domain.Enums;

namespace Application.Features;
public record AddFileTypeRequest(
FileTypeEnum Type,
string Extentions,
List<AddFileLogRequest> FileLogs,
List<AddFileFieldValidatorRequest> Validators);