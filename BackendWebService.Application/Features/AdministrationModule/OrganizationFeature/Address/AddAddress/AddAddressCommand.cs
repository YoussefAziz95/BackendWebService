using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddAddressCommand(string FullAddress) : IRequest<int>
{
    public bool IsAdministration { get; set; }
    public string Street { get; set; }
    public string Zone { get; set; }
    public string State { get; set; }
    public string City { get; set; }

    public IValidator<AddAddressCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddAddressCommand> validator)
    {
        validator.RuleFor(c => c.FullAddress)
            .NotEmpty().WithMessage("Please enter the full address");

        return validator;
    }
}
