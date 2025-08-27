namespace Application.Features;
public record AddFileLogRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
FileType FileType);