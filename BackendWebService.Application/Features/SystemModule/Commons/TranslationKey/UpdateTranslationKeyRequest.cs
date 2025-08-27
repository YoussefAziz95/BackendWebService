using Domain.Enums;

namespace Application.Features;
public record UpdateTranslationKeyRequest(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value);