using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Category")]
public class Category : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public Category ParentCategory { get; set; }
    public List<Category>? SubCategories { get; set; }
    public List<SupplierCategory> supplierCategories { get; set; }
}