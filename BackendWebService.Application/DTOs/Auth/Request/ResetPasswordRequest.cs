using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// DTO representing the request to reset a password.
    /// </summary>
    public class ResetPasswordRequest : BaseValidationModel<ResetPasswordRequest>
    {
        /// <summary>
        /// Gets or sets the token used for password reset.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the email associated with the password reset request.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        public string OldPassword { get; set; }
    }
}
