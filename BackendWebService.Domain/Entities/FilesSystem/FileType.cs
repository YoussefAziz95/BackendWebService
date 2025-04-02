using System.ComponentModel.DataAnnotations.Schema;

[Table("FileType")]
public class FileType : BaseEntity
{
    public string Type { get; set; }
    public string Extentions { get; set; }
}

