using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierDocumentRequest(
int SupplierAccountId,
int PreDocumentId,
 bool IsApproved,
 string? Comment,
 int? FileId) : IRequest<SupplierDocumentResponse>
{
    public IValidator<SupplierDocumentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierDocumentRequest> validator)
    {
        throw new NotImplementedException();
    }
}

