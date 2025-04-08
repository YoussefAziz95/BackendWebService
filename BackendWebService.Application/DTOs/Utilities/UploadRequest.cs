using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Utility;


public class UploadRequest
{
    public IFormFile? File { get; set; }
    public int Id { get; set; }
    public string CreatedDate { get; set; }
}
