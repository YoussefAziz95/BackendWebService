using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Actor")]
public class Actor : BaseEntity, IEntity, ITimeModification
{
    public int Id { get; set; }
    public int ActorId { get; set; }
    public string ActorType { get; set; }
    public int OwnerId { get; set; }
    public string OwnerType { get; set; }

}