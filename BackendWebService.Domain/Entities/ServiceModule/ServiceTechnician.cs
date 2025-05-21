
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("ServiceTechnician")]
public class ServiceTechnician : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int TechnicianId { get; set; }
    [Required]
    public int? CustomerServiceId { get; set; }

    public string? Notes { get; set; }
    public int? VoiceNoteId { get; set; }

    public int? FilesId { get; set; }

    [Required, MaxLength(500)]
    public string Description { get; set; }
    public string? AdditionalPhoneNumber { get; set; }
    [ForeignKey("TechnicianId")]
    public virtual Technician Technician { get; set; }
    [ForeignKey("CustomerServiceId")]
    public virtual CustomerService? CustomerService { get; set; }
    [ForeignKey("VoiceNoteId")]
    public virtual FileLog? VoiceNote { get; set; }
    [ForeignKey("FilesId")]
    public virtual FileLog? Files { get; set; }
}

