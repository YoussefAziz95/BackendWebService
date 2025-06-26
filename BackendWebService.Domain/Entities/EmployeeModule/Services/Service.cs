using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Service")]
public class Service : BaseEntity, IEntity, ITimeModification
{
    [Required, MaxLength(200)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [Required, MaxLength(100)]
    public string Code { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }
}
