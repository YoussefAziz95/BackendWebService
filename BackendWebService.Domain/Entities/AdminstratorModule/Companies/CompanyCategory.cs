using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("CompanyCategory")]
[Index(nameof(CompanyId), nameof(CategoryId), IsUnique = true)]
public class CompanyCategory : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CompanyId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }
}
