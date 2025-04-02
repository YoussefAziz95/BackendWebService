using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// DTO representing the request to confirm an email address.
    /// </summary>
    public class ConfirmEmailRequest : BaseValidationModel<ConfirmEmailRequest>
    {
        /// <summary>
        /// Gets or sets the token for email confirmation.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the email address to be confirmed.
        /// </summary>
        public string Email { get; set; }
    }
}
