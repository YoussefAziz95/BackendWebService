using Microsoft.AspNetCore.Http;

namespace BackendWebService.Application.DTOs;

public record UploadRequest(IFormFile? File);
public record FileResponse(string FullName, string FullPath, string Name, string Extention);
public record DeleteRequest(string FileName);