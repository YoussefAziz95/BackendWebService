using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record TranslationKeyAllResponse(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value):IConvertibleFromEntity<TranslationKey, TranslationKeyAllResponse>        
{
public static TranslationKeyAllResponse FromEntity(TranslationKey TranslationKey) =>
new TranslationKeyAllResponse(
TranslationKey.Key,
TranslationKey.Language,
TranslationKey.TableName,
TranslationKey.Field,
TranslationKey.Value);
}

