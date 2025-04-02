using Application.DTOs.Common;
using FluentValidation;

namespace Application.Validators.Category
{
    /// <summary>
    /// Validator for validating the properties of a DropDownRequest DTO.
    /// </summary>
    public class DropDownRequestValidator : AbstractValidator<DropDownRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DropDownRequestValidator class.
        /// </summary>
        public DropDownRequestValidator()
        {
            // Add validation rules here if needed
        }
    }
}
