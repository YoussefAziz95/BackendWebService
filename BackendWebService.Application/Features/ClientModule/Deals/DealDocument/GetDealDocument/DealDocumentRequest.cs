using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DealDocumentRequest(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId) : IRequest<DealDocumentResponse>
{
public IValidator<DealDocumentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DealDocumentRequest> validator)
{
throw new NotImplementedException();
}
}

