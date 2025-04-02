using Application.DTOs.SupplierCategory;
using FluentValidation;

namespace Application.Validators.CategoryName
{
    /// <summary>
    /// Validator for validating the properties of an AddSupplierCategoryRequest DTO.
    /// </summary>
    public sealed class AddSupplierCategoryRequestValidator : AbstractValidator<AddSupplierCategoryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the AddSupplierCategoryRequestValidator class.
        /// </summary>
        public AddSupplierCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid Category Id");

            RuleFor(x => x.SupplierId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid Supplier Id");
        }
    }
}
