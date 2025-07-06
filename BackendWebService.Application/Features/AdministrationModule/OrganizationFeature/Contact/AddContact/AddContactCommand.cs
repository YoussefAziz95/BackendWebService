using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddContactCommand(int CompanyId) : IRequest<int>
{
    public string? Value { get; set; }
    public string Type { get; set; }

    public IValidator<AddContactCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddContactCommand> validator)
    {
        validator.RuleFor(c => c.Type)
            .NotEmpty().WithMessage("Please specify the contact type");

        return validator;
    }
}
