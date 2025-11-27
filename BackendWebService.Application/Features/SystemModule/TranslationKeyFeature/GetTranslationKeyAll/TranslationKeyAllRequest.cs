using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record TranslationKeyAllRequest(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<TranslationKeyAllResponse>>
{
    public IValidator<TranslationKeyAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TranslationKeyAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

