using System.ComponentModel.DataAnnotations.Schema;

[Table("PreDocument")]
public class PreDocument : BaseEntity
{
    public string Name { get; set; }
    public bool? IsRequired { get; set; }
    public bool? IsMultiple { get; set; }
    public bool? IsLocal { get; set; }
    public int FileTypeId { get; set; }
}