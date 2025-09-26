using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AttachmentRequest(
int EmailId,
int FileId,
int FileFieldValidatorId) : IRequest<AttachmentResponse>
{
    public IValidator<AttachmentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AttachmentRequest> validator)
    {
        throw new NotImplementedException();
    }
}

