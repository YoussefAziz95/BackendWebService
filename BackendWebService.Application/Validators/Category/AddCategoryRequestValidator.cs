using Application.DTOs.Categories;
using FluentValidation;

public class AddCategoryRequestValidator : AbstractValidator<AddCategoryRequest>
{
    public AddCategoryRequestValidator()
    {
        RuleFor(x => x.Name)
     .NotEmpty()
     .WithMessage("Categories name cannot be empty.")  // Custom message for empty list
     .When(x => x.Name != null);


        RuleFor(x => x.ParentId)
            .GreaterThanOrEqualTo(0)
            .When(x => x.ParentId.HasValue)
            .WithMessage("ParentId must be a positive number or null.");
    }
}
