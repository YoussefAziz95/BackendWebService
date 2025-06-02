using Application.DTOs;
using FluentValidation;

public class AddServiceRequestValidator : AbstractValidator<AddServiceRequest>
{
    public AddServiceRequestValidator()
    {
        // Validate that Name list should not be empty
        RuleFor(x => x.Name)
     .NotEmpty()
     .WithMessage("Services name cannot be empty.")
     .Must(name => name != null && name.Any())
     .WithMessage("Services name cannot be empty.");


        // Validate that Code is not empty
        RuleFor(x => x.Code)
        .NotEmpty()
        .WithMessage("Services code is required.")
        .MinimumLength(3)
        .WithMessage("Services code must be at least 3 characters long.");


        // Validate that CategoryId is greater than 0
        RuleFor(x => x.CategoryName)
            .NotEmpty()
            .WithMessage("Categories is required");
    }
}
