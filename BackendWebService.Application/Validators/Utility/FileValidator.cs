using Domain.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Validators.Utility
{
    /// <summary>
    /// Validator for validating file properties.
    /// </summary>
    public sealed class FileValidator : AbstractValidator<IFormFile>
    {
        /// <summary>
        /// Initializes a new instance of the FileValidator class.
        /// </summary>
        public FileValidator()
        {
            RuleFor(x => x.Length)
                .NotNull()
                .LessThanOrEqualTo(AppConstants.DocumentMaxAllowedSize)
                .WithMessage("FileLog size is larger than allowed");

            RuleFor(x => x.ContentType)
                .NotNull()
                .Must(x => x.Equals(AppConstants.ImageAllowedExtensions) || x.Equals(AppConstants.DocumentAllowedExtensions))
                .WithMessage("FileLog type is not allowed");
        }
    }
}
