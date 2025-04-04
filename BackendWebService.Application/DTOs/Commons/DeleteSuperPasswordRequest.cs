using Application.Validators.Common;

namespace Application.DTOs.Common
{
    /// <summary>
    /// Request model for deleting with a super password.
    /// </summary>
    public class DeleteSuperPasswordRequest : AsyncBaseValidationModel<DeleteSuperPasswordRequest>
    {
        /// <summary>
        /// Gets or sets the super password for authentication.
        /// </summary>
        public required string SuperPassword { get; set; }
    }
}

