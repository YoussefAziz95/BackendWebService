using Application.DTOs.Suppliers.Request;

using FluentValidation;

public class AddSupplierRequestValidator : AbstractValidator<AddSupplierRequest>
{
    public AddSupplierRequestValidator()
    {
        // Name validation
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Suppliers name is required.")
            .WithMessage("Suppliers name must contain at least one entry.");


        // Address validation

        RuleFor(x => x.Country)
               .NotEmpty()
               .WithMessage("Country is required.");
        RuleFor(x => x.City)
        .NotEmpty()
        .WithMessage("City is required.");
        RuleFor(x => x.StreetAddress)
        .NotEmpty()
        .WithMessage("Street Address is required.");

        RuleFor(x => x.TaxNo)
                .NotEmpty()
                .WithMessage("Tax number is required.")
                .Matches(@"^\d+$")
                .WithMessage("Tax number must be numeric.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("EmailDto address is required.")
            .EmailAddress()
            .WithMessage("Invalid email address.");

        RuleFor(x => x.Phone)
.Cascade(CascadeMode.Stop) // Stops at first failure
.NotEmpty()
.WithMessage("Phone number is required.")
.Matches(@"^\d+$")
.WithMessage("Phone number must be numeric.")
.When(x => !string.IsNullOrEmpty(x.Phone));

    }
}
