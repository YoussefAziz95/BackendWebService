using Domain.Enums;

namespace Application.Features;
public record AddTranslationKeyRequest(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value);