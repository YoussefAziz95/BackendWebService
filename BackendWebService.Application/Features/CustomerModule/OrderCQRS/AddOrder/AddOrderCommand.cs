using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;
using System.Text.Json.Serialization;

namespace Application.Features;
public record AddOrderCommand(string OrderName) : IRequest<int>

{
    [JsonIgnore]
    public int UserId { get; set; }

    public IValidator<AddOrderCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddOrderCommand> validator)
    {
        validator.RuleFor(c => c.OrderName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter your role name");

        return validator;
    }

}