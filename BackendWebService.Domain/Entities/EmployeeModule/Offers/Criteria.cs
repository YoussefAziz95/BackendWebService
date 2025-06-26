using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Criteria")]
public class Criteria : BaseEntity, IEntity, ITimeModification
{
    [Required, StringLength(255)]
    public string Term { get; set; }

    public bool IsRequired { get; set; } = false;

    [Required]
    public int OfferId { get; set; }

    [ForeignKey(nameof(OfferId))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Offer Offer { get; set; }

    [Required, Range(1, 100)]
    public int Weight { get; set; }

    [Required]
    public int FileTypeId { get; set; }

    // Optional: future navigation to FileType table
    // public FileType FileType { get; set; }
}
