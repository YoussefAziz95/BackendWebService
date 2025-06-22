using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Criteria : BaseEntity
{
    [Required, StringLength(255)]
    public string Term { get; set; }

    public bool IsRequired { get; set; } = false; // Default to false for clarity

    [Required]
    public int OfferId { get; set; }

    [Required, Range(1, 100)]
    public int Weight { get; set; }

    [ForeignKey(nameof(OfferId))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Offer Offer { get; set; }

    [Required]
    public int FileTypeId { get; set; }
}
