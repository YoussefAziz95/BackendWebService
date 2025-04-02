using Application.DTOs.Supplier.Request;
using FluentValidation;

namespace Application.Validators.Supplier
{
    /// <summary>
    /// Validator for validating requests to update a supplier.
    /// </summary>
    public class UpdateSupplierRequestValidator : AbstractValidator<UpdateSupplierRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSupplierRequestValidator"/> class.
        /// </summary>
        public UpdateSupplierRequestValidator()
        {
            When(x => !string.IsNullOrEmpty(x.Phone), () =>
            {
                RuleFor(x => x.Phone)
                    .NotEmpty().MaximumLength(11);
            });

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("EmailDto Address is required.")
                    .EmailAddress()
                    .WithMessage("Invalid EmailDto Address.");
            });
        }
    }
}
