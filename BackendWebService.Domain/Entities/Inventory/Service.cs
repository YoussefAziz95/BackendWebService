using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Service")]
public class Service : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}