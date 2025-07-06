using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddCriteriaCommand(string Term) : IRequest<int>
{
    public int FileTypeId { get; set; }
    public bool? IsRequired { get; set; }
    public int Weight { get; set; }
    public int OfferId { get; set; }

    public IValidator<AddCriteriaCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCriteriaCommand> validator)
    {
        validator.RuleFor(c => c.Term).NotEmpty().WithMessage("Please enter a term");
        validator.RuleFor(c => c.Weight).InclusiveBetween(1, 100).WithMessage("Weight must be between 1 and 100");
        return validator;
    }
}
