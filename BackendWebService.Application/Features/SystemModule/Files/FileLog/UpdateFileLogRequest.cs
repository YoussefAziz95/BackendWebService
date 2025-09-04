namespace Application.Features;
public record UpdateFileLogRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
FileType FileType);