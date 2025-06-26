using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("LDAPConfig")]
public class LDAPConfig : BaseEntity, IEntity, ITimeModification
{
    public int ConfigurationId { get; set; }
    public ConfigurationEnum ConfigurationType { get; set; }
    public string ServerAddress { get; set; }
    public string CN { get; set; }
    public string DC { get; set; }
}