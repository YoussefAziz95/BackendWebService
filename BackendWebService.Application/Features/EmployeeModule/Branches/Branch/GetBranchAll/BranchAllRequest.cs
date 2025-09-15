using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchAllRequest(
string FranchiseName,
string? FranchiseSlogan,
string LogoUrl,
string PhoneNumber,
string? WebsiteUrl,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<BranchAllResponse>>
{
    public IValidator<BranchAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

