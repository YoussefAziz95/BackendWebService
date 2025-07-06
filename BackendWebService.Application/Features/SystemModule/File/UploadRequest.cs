using Microsoft.AspNetCore.Http;

namespace Application.Features;
public record UploadRequest(
IFormFile? File);
