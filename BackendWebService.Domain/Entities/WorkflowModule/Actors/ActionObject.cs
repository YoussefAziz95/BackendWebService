using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ActionObject")]
public class ActionObject : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int ActionId { get; set; }

    [Required, MaxLength(50)]
    public string ActionType { get; set; } = string.Empty;

    [Required]
    public int ObjectId { get; set; }

    [Required, MaxLength(50)]
    public string ObjectType { get; set; } = string.Empty;
}
