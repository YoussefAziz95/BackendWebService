using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("PortionType")]
public class PortionType : BaseEntity, IEntity, ITimeModification
{
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? UnitOfMeasure { get; set; }

    public virtual ICollection<Portion> Portions { get; set; }
}
