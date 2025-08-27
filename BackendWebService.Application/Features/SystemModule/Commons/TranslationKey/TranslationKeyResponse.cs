using Domain.Enums;

namespace Application.Features;
public record TranslationKeyResponse(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value);