using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// Request model for revoking a token.
    /// </summary>
    public class RevokeTokenRequest : BaseValidationModel<RevokeTokenRequest>
    {
        /// <summary>
        /// Gets or sets the token to be revoked.
        /// </summary>
        public string Token { get; set; }
    }
}
