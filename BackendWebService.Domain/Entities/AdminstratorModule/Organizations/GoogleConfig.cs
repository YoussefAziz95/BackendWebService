using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

[Table("GoogleConfig")]
public class GoogleConfig : BaseEntity, IEntity, ITimeModification
{
    public int ConfigurationId { get; set; }

    public ConfigurationEnum ConfigurationType { get; set; }

    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
