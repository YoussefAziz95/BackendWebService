using FluentValidation;
using Application.DTOs.PreDocument;

public class UpdatePreDocumentRequestValidator : AbstractValidator<UpdatePreDocumentRequest>
{
    public UpdatePreDocumentRequestValidator()
    {
        // Validate that id is required and greater than 0
        RuleFor(x => x.id)
            .GreaterThan(0)
            .WithMessage("Document type ID must be a positive number.");

        // Validate that if Name is provided, it has at least 3 characters
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Document type name is required.")
            .MinimumLength(3)
            .WithMessage("Document type name must be at least 3 characters long.");

        // Validate that FileTypeId is greater than 0
        RuleFor(x => x.FileTypeId)
            .GreaterThan(0)
            .WithMessage("FileLog Type ID must be a positive number.");
    }
}
