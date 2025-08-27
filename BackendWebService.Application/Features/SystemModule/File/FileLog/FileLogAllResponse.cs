using Domain.Enums;

namespace Application.Features;
public record FileLogAllResponse(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
FileType FileType);

