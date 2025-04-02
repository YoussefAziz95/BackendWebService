using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// Represents a request model for forgetting password.
    /// </summary>
    public class ForgetPasswordRequest : BaseValidationModel<ForgetPasswordRequest>
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }
    }
}
