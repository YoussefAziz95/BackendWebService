using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierCategoryAllRequest(
int SupplierId,
 int CategoryId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<SupplierCategoryAllResponse>>
{
    public IValidator<SupplierCategoryAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierCategoryAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

