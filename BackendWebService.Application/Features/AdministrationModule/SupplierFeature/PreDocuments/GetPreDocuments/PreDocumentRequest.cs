using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PreDocumentRequest(
string Name,
bool IsRequired,
bool IsMultiple,
bool IsLocal,
int FileTypeId) : IRequest<PreDocumentResponse>
{
public IValidator<PreDocumentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PreDocumentRequest> validator)
{
throw new NotImplementedException();
}
}

