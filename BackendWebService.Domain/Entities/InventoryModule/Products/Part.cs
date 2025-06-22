using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Part")]
public class Part : BaseEntity, IEntity, ITimeModification
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string Image { get; set; }
    public string PartNumber { get; set; }
    public string Manufacturer { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }


}
