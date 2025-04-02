using Application.DTOs.SupplierDocument;
using FluentValidation;

public class AddSupplierDocumentRequestValidator : AbstractValidator<AddSupplierDocumentRequest>
{
    public AddSupplierDocumentRequestValidator()
    {
        // UserId validation
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("Customer ID must be a positive integer.");

        // CompanyId validation
        RuleFor(x => x.CompanyId)
            .GreaterThan(0)
            .WithMessage("Company ID must be a positive integer.");

        // FileId validation
        RuleFor(x => x.FileId)
            .GreaterThan(0)
            .WithMessage("FileLog ID must be a positive integer.");

        // PreDocumentId validation
        RuleFor(x => x.PreDocumentId)
            .GreaterThan(0)
            .WithMessage("Document Type ID must be a positive integer.");
    }
}
