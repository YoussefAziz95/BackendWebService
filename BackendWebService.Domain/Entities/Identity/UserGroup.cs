using System.ComponentModel.DataAnnotations.Schema;

[Table("UserGroup")]
public class UserGroup : BaseEntity
{
    public required int GroupId { get; set; }
    public required int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual Group Group { get; set; }
}