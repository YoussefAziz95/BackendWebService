using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierRequest(
 int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status) : IRequest<SupplierResponse>
{
    public IValidator<SupplierRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierRequest> validator)
    {
        throw new NotImplementedException();
    }
}

