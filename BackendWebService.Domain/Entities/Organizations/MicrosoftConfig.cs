using System.ComponentModel.DataAnnotations.Schema;

[Table("MicrosoftConfig")]
public class MicrosoftConfig : BaseEntity
{
    public int ConfigurationId { get; set; }
    public Configuration Configuration { get; set; }
    public string ClientId { get; set; }
    public string TenantId { get; set; }
    public string Audience { get; set; }
    public string Instance { get; set; }
}