using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;

namespace Application.DTOs.Users
{
    /// <summary>
    /// Represents a request model for activating or deactivating OTP.
    /// </summary>
    public class ActivateDeactivateOtpRequest : BaseValidationModel<ActivateDeactivateOtpRequest>, ICreateMapper<User>
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
