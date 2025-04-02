using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// Request model for user login.
    /// </summary>
    public class LoginRequest : BaseValidationModel<LoginRequest>
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
