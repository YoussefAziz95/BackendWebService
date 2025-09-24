using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierCategoryRequest(
int SupplierId,
int CategoryId) : IRequest<SupplierCategoryResponse>
{
    public IValidator<SupplierCategoryRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierCategoryRequest> validator)
    {
        throw new NotImplementedException();
    }
}

