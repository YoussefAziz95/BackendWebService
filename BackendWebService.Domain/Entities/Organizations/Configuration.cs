using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Recipient")]
public class Configuration : BaseEntity
{
    public int ConfigurationTypeId { get; set; }
    public ConfigurationEnum ConfigurationType { get; set; }
}