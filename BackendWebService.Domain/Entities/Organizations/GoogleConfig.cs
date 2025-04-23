using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("GoogleConfig")]
public class GoogleConfig : BaseEntity, IEntity, ITimeModification
{
    public int ConfigurationId { get; set; }
    [ForeignKey("ConfigurationId")]
    public AppConfiguration Configuration { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}

