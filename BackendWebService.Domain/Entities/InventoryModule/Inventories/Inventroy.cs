using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("Inventroy")]
public class Inventroy : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }
    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }
}