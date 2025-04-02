using Application.Validators.Common;

namespace Application.DTOs.User
{
    /// <summary>
    /// Represents a request model for changing password.
    /// </summary>
    public class ChangePasswordRequest : BaseValidationModel<ChangePasswordRequest>
    {
        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        public required string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        public required string NewPassword { get; set; }
    }
}
