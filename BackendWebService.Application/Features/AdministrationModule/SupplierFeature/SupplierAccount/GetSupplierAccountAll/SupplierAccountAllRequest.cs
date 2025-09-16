using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierAccountAllRequest(
int CompanyId,
int SupplierId,
bool IsApproved,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<SupplierAccountAllResponse>>
{
    public IValidator<SupplierAccountAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierAccountAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

