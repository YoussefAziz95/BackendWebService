using Application.Validators.Common;

namespace Application.DTOs.User
{
    /// <summary>
    /// Represents a request model for activating or deactivating OTP.
    /// </summary>
    public class ActivateDeactivateOtpRequest : BaseValidationModel<ActivateDeactivateOtpRequest>
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has OTP enabled.
        /// </summary>
        public required bool HasOtp { get; set; }
    }
}
