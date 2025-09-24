using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierAccountRequest(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate) : IRequest<SupplierAccountResponse>
{
    public IValidator<SupplierAccountRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierAccountRequest> validator)
    {
        throw new NotImplementedException();
    }
}

