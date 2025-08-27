namespace Application.Features;
public record FileLogResponse(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
FileType FileType);