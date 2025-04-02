namespace Application.DTOs.Common
{
    /// <summary>
    /// Represents a response model for downloading a file.
    /// </summary>
    public class DownloadResponse
    {
        /// <summary>
        /// Gets or sets the path to the file to be downloaded.
        /// </summary>
        public string? FilePath { get; set; }

        /// <summary>
        /// Gets or sets the MIME type of the file.
        /// </summary>
        public string? MimeType { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string? FileName { get; set; }
    }
}
