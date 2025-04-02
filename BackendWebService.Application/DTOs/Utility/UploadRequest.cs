using Application.Validators.Common;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Utility
{
    /// <summary>
    /// Represents a request model for uploading a file.
    /// </summary>
    public class UploadRequest
    {
        /// <summary>
        /// Gets or sets the file to be uploaded.
        /// </summary>
        public IFormFile? File { get; set; }
        public int Id { get; set; }
        public string CreatedDate { get; set; }
    }
}
