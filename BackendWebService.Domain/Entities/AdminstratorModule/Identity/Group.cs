using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Group")]
public class Group : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }
    public int? ActorId { get; set; }

    public virtual ICollection<UserGroup>? UserGroups { get; set; }
}
