using Application.Validators.Common;

namespace Application.DTOs.Utility
{
    /// <summary>
    /// Represents a request model for deleting a file.
    /// </summary>
    public class DeleteRequest : BaseValidationModel<UploadRequest>
    {
        /// <summary>
        /// Gets or sets the name of the file to be deleted.
        /// </summary>
        public required string FileName { get; set; }
    }
}
