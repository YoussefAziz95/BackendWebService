using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierAllRequest(
int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<SupplierAllResponse>>
{
    public IValidator<SupplierAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

