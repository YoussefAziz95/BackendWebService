using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerDocumentRequest(
int ConsumerAccountId,
int PreDocumentId,
bool IsApproved,
string? Comment,
int? FileId) : IRequest<ConsumerDocumentResponse>
{
public IValidator<ConsumerDocumentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerDocumentRequest> validator)
{
throw new NotImplementedException();
}
}

