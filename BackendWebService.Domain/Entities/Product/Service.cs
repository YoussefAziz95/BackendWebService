using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Service")]
public class Service : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}