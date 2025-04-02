using System.ComponentModel.DataAnnotations.Schema;

[Table("LDAPConfig")]
public class LDAPConfig : BaseEntity
{
    public int ConfigurationId { get; set; }
    public Configuration Configuration { get; set; }
    public string ServerAddress { get; set; }
    public string CN { get; set; }
    public string DC { get; set; }
}