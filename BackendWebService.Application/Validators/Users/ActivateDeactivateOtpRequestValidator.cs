using Application.DTOs.User;
using FluentValidation;

namespace Application.Validators.Users
{
    /// <summary>
    /// Validator for validating the properties of an ActivateDeactivateOtpRequest DTO.
    /// </summary>
    public sealed class ActivateDeactivateOtpRequestValidator : AbstractValidator<ActivateDeactivateOtpRequest>
    {
        /// <summary>
        /// Initializes a new instance of the ActivateDeactivateOtpRequestValidator class.
        /// </summary>
        public ActivateDeactivateOtpRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.HasOtp).NotEmpty();
        }
    }
}
