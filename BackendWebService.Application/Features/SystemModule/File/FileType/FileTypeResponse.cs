using Domain.Enums;

namespace Application.Features;
public record FileTypeResponse(
FileTypeEnum Type,
string Extentions,
List<FileLogResponse> FileLogs,
List<FileFieldValidatorResponse> Validators);