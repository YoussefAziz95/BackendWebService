using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record TranslationKeyRequest(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value) : IRequest<TranslationKeyResponse>
{
public IValidator<TranslationKeyRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TranslationKeyRequest> validator)
{
throw new NotImplementedException();
}
}

