using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateTranslationKeyRequest(
string Key,
LanguageEnum Language,
TableNameEnum TableName,
string Field,
string Value):IConvertibleToEntity<TranslationKey>
{
public TranslationKey ToEntity() => new TranslationKey
{
Key = Key,
Language = Language,
TableName = TableName,
Field = Field,
Value = Value};
}