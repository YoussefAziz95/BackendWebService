using Application.DTOs.Category;
using FluentValidation;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        // Validate that Name list should not be empty if provided
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Category name cannot be empty.")  // Custom message for empty list
            .When(x => x.Name != null);

        // Apply validation for each item in the Name list
       
        // Validate ParentId (optional, but must be a positive number if provided)
        RuleFor(x => x.ParentId)
            .GreaterThanOrEqualTo(0)
            .When(x => x.ParentId.HasValue)
            .WithMessage("Parent ID must be a positive number or null.");
    }
}
