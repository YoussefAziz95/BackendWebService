using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddOrganizationCommand(string Name) : IRequest<int>
{
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public OrganizationEnum Type { get; set; }
    public string FaxNo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string TaxNo { get; set; }
    public int FileId { get; set; }

    public IValidator<AddOrganizationCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddOrganizationCommand> validator)
    {
        validator.RuleFor(c => c.Name).NotEmpty().WithMessage("Please enter the organization name");
        validator.RuleFor(c => c.Email).EmailAddress().When(c => !string.IsNullOrEmpty(c.Email));
        return validator;
    }
}
