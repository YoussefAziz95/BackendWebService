using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TranslationKey")]
public class TranslationKey : BaseEntity, IEntity, ITimeModification
{
    public string Key { get; set; } 
    public LanguageEnum Language { get; set; }
    public TableNameEnum TableName { get; set; }
    public string Field { get; set; }
    public string Value { get; set; }
}