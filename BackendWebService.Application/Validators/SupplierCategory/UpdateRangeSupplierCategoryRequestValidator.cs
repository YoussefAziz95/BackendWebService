using FluentValidation;
using Application.DTOs.SupplierCategory;

namespace Application.Validators.SupplierCategory
{
    /// <summary>
    /// Validator for validating requests to update a range of supplier categories.
    /// </summary>
    public sealed class UpdateRangeSupplierCategoryRequestValidator : AbstractValidator<UpdateRangeSupplierCategoryRequest >
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRangeSupplierCategoryRequestValidator"/> class.
        /// </summary>
        public UpdateRangeSupplierCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid Category Id");

            RuleFor(x => x.CompanyId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid Company Id");
        }
    }
}
