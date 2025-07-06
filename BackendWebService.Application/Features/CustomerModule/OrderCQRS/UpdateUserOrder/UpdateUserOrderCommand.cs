using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;
using SharedKernel.ValidationBase.Contracts;
using System.Text.Json.Serialization;

namespace Application.Features;
public record UpdateUserOrderCommand
    (int OrderId, string OrderName) : IRequest<bool>, IValidatableModel<UpdateUserOrderCommand>
{
    [JsonIgnore]
    public int UserId { get; set; }

    public IValidator<UpdateUserOrderCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UpdateUserOrderCommand> validator)
    {
        validator.RuleFor(c => c.OrderId).NotEmpty().GreaterThan(0);
        validator.RuleFor(c => c.OrderName).NotEmpty().NotNull();

        return validator;
    }
};