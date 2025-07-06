using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddManagerCommand(int CompanyId) : IRequest<int>
{
    public string Name { get; set; }
    public string Position { get; set; }

    public IValidator<AddManagerCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddManagerCommand> validator)
    {
        validator.RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Please enter the manager's name")
            .MaximumLength(150).WithMessage("Name cannot exceed 150 characters");

        validator.RuleFor(c => c.Position)
            .NotEmpty().WithMessage("Please enter the manager's position");

        return validator;
    }
}
