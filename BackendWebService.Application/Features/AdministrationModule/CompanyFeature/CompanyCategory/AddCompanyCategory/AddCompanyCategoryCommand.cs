using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddCompanyCategoryCommand(int CompanyId, int CategoryId) : IRequest<int>
{
    public IValidator<AddCompanyCategoryCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCompanyCategoryCommand> validator)
    {
        validator.RuleFor(c => c.CompanyId)
            .GreaterThan(0).WithMessage("CompanyId is required");

        validator.RuleFor(c => c.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId is required");

        return validator;
    }
}
