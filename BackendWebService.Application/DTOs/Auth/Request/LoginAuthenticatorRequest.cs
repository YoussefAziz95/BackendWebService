using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// DTO representing the request to authenticate a login.
    /// </summary>
    public class LoginAuthenticatorRequest : BaseValidationModel<LoginAuthenticatorRequest>
    {
        /// <summary>
        /// Gets or sets the client ID for authentication.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the access token for authentication.
        /// </summary>
        public string AccessToken { get; set; }
    }
}
