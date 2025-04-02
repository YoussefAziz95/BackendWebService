using Application.DTOs.SupplierDocument;
using FluentValidation;

namespace Application.Validators.SupplierDocument
{
    public class UpdateSupplierDocumentRequestValidator : AbstractValidator<UpdateSupplierDocumentRequest>
    {
        public UpdateSupplierDocumentRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Document Id must be greater than 0.");


            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Customer Id must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Customer Id must be greater than 0.");
        }
    }
}
