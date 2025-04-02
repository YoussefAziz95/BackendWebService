using Domain.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Validators.Company
{
    /// <summary>
    /// Validator for validating image files.
    /// </summary>
    public sealed class ImageFileValidator : AbstractValidator<IFormFile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFileValidator"/> class.
        /// </summary>
        public ImageFileValidator()
        {
            RuleFor(x => x.Length)
                .NotNull()
                .LessThanOrEqualTo(AppConstants.ImageMaxAllowedSize)
                .WithMessage("FileLog size is larger than allowed");

            RuleFor(x => x.ContentType)
                .NotNull()
                .Must(x => x.Equals(AppConstants.ImageAllowedExtensions))
                .WithMessage("FileLog type is not allowed");
        }
    }
}
