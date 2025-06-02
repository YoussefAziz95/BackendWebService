
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("TechnicianService")]
public class TechnicianService : BaseEntity, IEntity, ITimeModification
{
    public int? TechnicianId { get; set; }
    
    public int? CustomerServiceId { get; set; }
    [ForeignKey("CustomerServiceId")]
    public virtual CustomerService? CustomerService { get; set; }

    public string? Notes { get; set; }
    public int? VoiceNoteId { get; set; }

    public int? FilesId { get; set; }

    [Required, MaxLength(500)]
    public string Description { get; set; }
    public string? AdditionalPhoneNumber { get; set; }
    [ForeignKey("VoiceNoteId")]
    public virtual FileLog? VoiceNote { get; set; }
    [ForeignKey("FilesId")]
    public virtual FileLog? Files { get; set; }
}

