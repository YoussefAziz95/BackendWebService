using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("AppConfiguration")]
public class AppConfiguration : BaseEntity, IEntity, ITimeModification
{
    public int ConfigurationTypeId { get; set; }
    public ConfigurationEnum ConfigurationType { get; set; }
}