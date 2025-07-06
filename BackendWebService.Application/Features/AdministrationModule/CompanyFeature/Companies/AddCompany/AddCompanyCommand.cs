using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddCompanyCommand(string CompanyName) : IRequest<int>
{
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public string RegistrationNumber { get; set; }
    public string TaxNo { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
    public string? Fax { get; set; }
    public string? Phone { get; set; }
    public int? RoleId { get; set; }

    public List<AddAddressRequest>? Addresses { get; set; }
    public List<AddContactCommand>? Contacts { get; set; }

    public IValidator<AddCompanyCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCompanyCommand> validator)
    {
        validator.RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name is required");

        return validator;
    }
}
