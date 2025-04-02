using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// Request model for confirming OTP (One Time Password).
    /// </summary>
    public class ConfirmOtpRequest : BaseValidationModel<ConfirmOtpRequest>
    {
        /// <summary>
        /// Gets or sets the email associated with the OTP.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the OTP (One Time Password) to confirm.
        /// </summary>
        public string Otp { get; set; }
    }
}
