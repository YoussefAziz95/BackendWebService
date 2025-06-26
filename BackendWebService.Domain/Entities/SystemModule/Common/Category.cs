using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Category")]
public class Category : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }

    public int? ParentId { get; set; }

    public int? FileId { get; set; }

    [ForeignKey(nameof(FileId))]
    public FileLog? File { get; set; }

    [ForeignKey(nameof(ParentId))]
    public virtual Category? ParentCategory { get; set; }

    [InverseProperty(nameof(ParentCategory))]
    public List<Category>? SubCategories { get; set; }
}
 