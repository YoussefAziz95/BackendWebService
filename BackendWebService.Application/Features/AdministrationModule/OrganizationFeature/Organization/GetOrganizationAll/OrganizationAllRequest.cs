using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OrganizationAllRequest(
string Country,
string City,
string StreetAddress,
string FaxNo,
string Phone,
string Email,
string TaxNo,
int FileId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<OrganizationAllResponse>>
{
    public IValidator<OrganizationAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OrganizationAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

