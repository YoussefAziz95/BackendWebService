using Domain.Enums;

namespace Application.Features;
public record TranslationKeyAllResponse(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value);

