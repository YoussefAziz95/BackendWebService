using Application.DTOs.Utility;
using FluentValidation;

namespace Application.Validators.Utility
{
    /// <summary>
    /// Validator for upload requests.
    /// </summary>
    public sealed class UploadRequestValidator : AbstractValidator<UploadRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadRequestValidator"/> class.
        /// </summary>
        public UploadRequestValidator()
        {
            RuleFor(x => x.File)
                .SetValidator(new FileValidator());
        }
    }
}
