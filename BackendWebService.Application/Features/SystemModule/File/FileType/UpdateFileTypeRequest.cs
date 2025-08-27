using Domain.Enums;

namespace Application.Features;
public record UpdateFileTypeRequest(FileTypeEnum Type,
string Extentions,
List<UpdateFileLogRequest> FileLogs,
List<UpdateFileFieldValidatorRequest> Validators);