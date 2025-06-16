using Domain;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("PreDocument")]
public class PreDocument : BaseEntity, IEntity, ITimeModification
{
    public string Name { get; set; }
    public bool? IsRequired { get; set; }
    public bool? IsMultiple { get; set; }
    public bool? IsLocal { get; set; }
    public int FileTypeId { get; set; }
}