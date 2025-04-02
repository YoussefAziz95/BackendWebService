using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Service")]
public class Service : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}