using Application.DTOs.SupplierCategories;
using FluentValidation;

namespace Application.Validators.SupplierCategory
{
    /// <summary>
    /// Validator for validating requests to update a supplier category.
    /// </summary>
    public sealed class UpdateSupplierCategoryRequestValidator : AbstractValidator<UpdateSupplierCategoryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSupplierCategoryRequestValidator"/> class.
        /// </summary>
        public UpdateSupplierCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid Categories Id");

            RuleFor(x => x.CompanyId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid Companies Id");
        }
    }
}
