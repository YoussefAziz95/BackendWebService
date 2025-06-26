using Domain;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Actor")]
public class Actor : BaseEntity, IEntity, ITimeModification
{
    public int ActorId { get; set; }
    public string ActorType { get; set; }

    public int OwnerId { get; set; }
    public string OwnerType { get; set; }
}
