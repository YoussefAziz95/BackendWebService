using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Actor")]
public class Actor : BaseEntity
{


    [Key]
    public int Id { get; set; } // Auto-increment primary key

    public int UserId { get; set; }  
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public string ActorType { get; set; }
    public int OwnerId { get; set; }
    public string OwnerType { get; set; }

}