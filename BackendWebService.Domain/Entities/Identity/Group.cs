using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Group")]
public class Group : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public List<UserGroup> UserGroups { get; set; }
    public int? ActorId { get; set; }
}
