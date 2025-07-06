namespace Application.Features;
public record FileResponse(
string FileName,
string FullPath,
string Extention,
string? FileLink = null);