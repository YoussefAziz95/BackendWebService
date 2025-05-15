using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Service")]
public class Service : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int CategoryId { get; set; } // FK to Category
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; } // FK to Category
    public string Code { get; set; } // Unique code for the service

}