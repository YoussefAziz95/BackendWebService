using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
namespace Domain;

[Table("Category")]
public class Category : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }

    public string? Image { get; set; }
    [AllowNull]
    public int? ParentId { get; set; }
    public int? FileId { get; set; }
    [ForeignKey("FileId")]
    public FileLog? File { get; set; }

    [ForeignKey("ParentId")]
    public virtual Category? ParentCategory { get; set; }
    public List<Category>? SubCategories { get; set; }
}