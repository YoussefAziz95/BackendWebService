using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record TranslationKeyResponse(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value) : IConvertibleFromEntity<TranslationKey, TranslationKeyResponse>
{
    public static TranslationKeyResponse FromEntity(TranslationKey TranslationKey) =>
    new TranslationKeyResponse(
    TranslationKey.Key,
    TranslationKey.Language,
    TranslationKey.TableName,
    TranslationKey.Field,
    TranslationKey.Value);
}
