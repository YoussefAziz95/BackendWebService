using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchRequest(
string FranchiseName,
string? FranchiseSlogan,
string LogoUrl,
string PhoneNumber,
string? WebsiteUrl) : IRequest<BranchResponse>
{
    public IValidator<BranchRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchRequest> validator)
    {
        throw new NotImplementedException();
    }
}

