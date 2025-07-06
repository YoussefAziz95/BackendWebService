using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddCategoryCommand(string Name) : IRequest<int>
{
    public int? ParentId { get; set; }
    public int FileId { get; set; }

    public IValidator<AddCategoryCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCategoryCommand> validator)
    {
        validator.RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Please enter a category name");

        return validator;
    }
}
