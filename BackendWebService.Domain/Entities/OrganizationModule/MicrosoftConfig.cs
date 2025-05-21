using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("MicrosoftConfig")]
public class MicrosoftConfig : BaseEntity, IEntity, ITimeModification
{
    public int ConfigurationId { get; set; }
    public AppConfiguration Configuration { get; set; }
    public string ClientId { get; set; }
    public string TenantId { get; set; }
    public string Audience { get; set; }
    public string Instance { get; set; }
}