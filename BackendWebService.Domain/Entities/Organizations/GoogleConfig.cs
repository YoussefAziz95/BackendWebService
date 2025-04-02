using System.ComponentModel.DataAnnotations.Schema;

[Table("GoogleConfig")]
public class GoogleConfig : BaseEntity
{
    public int ConfigurationId { get; set; }
    [ForeignKey("ConfigurationId")]
    public Configuration Configuration { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}

