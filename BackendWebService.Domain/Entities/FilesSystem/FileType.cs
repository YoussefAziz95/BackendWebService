using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("FileType")]
public class FileType : BaseEntity, IEntity, ITimeModification
{
    public string Type { get; set; }
    public string Extentions { get; set; }
}

