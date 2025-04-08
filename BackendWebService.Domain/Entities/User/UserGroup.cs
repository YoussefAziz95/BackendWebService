using Domain;
using System.ComponentModel.DataAnnotations.Schema;

[Table("UserGroup")]
public class UserGroup : BaseEntity, IEntity, ITimeModification
{

    public required int GroupId { get; set; }
    public required int UserId { get; set; }

    [ForeignKey("ActorId")]
    public virtual User User { get; set; }
    [ForeignKey("GroupId")]
    public virtual Group Group { get; set; }

}