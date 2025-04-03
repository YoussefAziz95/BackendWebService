using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Configuration")]
public class Configuration : BaseEntity, IEntity, ITimeModification
{
    public int ConfigurationTypeId { get; set; }
    public ConfigurationEnum ConfigurationType { get; set; }
}