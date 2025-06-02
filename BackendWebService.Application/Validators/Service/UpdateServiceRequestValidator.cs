using Application.DTOs;
using FluentValidation;

public class UpdateServiceRequestValidator : AbstractValidator<UpdateServiceRequest>
{
    public UpdateServiceRequestValidator()
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

        
    }
}
