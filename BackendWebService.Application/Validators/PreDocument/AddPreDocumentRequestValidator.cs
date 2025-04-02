using FluentValidation;
using Application.DTOs.PreDocument;

public class AddPreDocumentRequestValidator : AbstractValidator<AddPreDocumentRequest>
{
    public AddPreDocumentRequestValidator()
    {
        // Validate that Name is not empty and has at least 3 characters
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Document type name is required.")
            .MinimumLength(3)
            .WithMessage("Document type name must be at least 3 characters long.");

        // Validate that FileTypeId is greater than 0
        RuleFor(x => x.FileTypeId)
            .GreaterThan(0)
            .WithMessage("FileLog Type ID must be a positive number.");

        // Validate that UserId is required and greater than 0
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("Customer ID is required and must be a positive number.");
    }
}
