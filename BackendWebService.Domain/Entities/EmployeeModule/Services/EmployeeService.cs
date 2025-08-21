using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("EmployeeService")]
public class EmployeeService : BaseEntity, IEntity, ITimeModification
{
    public int? EmployeeId { get; set; } // FK to Employee

    public int? CustomerServiceId { get; set; }

    [ForeignKey(nameof(CustomerServiceId))]
    public virtual CustomerService? CustomerService { get; set; }

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public int? VoiceNoteId { get; set; }

    [ForeignKey(nameof(VoiceNoteId))]
    public virtual FileLog? VoiceNote { get; set; }

    public int? FilesId { get; set; }

    [ForeignKey(nameof(FilesId))]
    public virtual FileLog? Files { get; set; }

    [Required, MaxLength(500)]
    public string Description { get; set; }

    [MaxLength(20)]
    public string? AdditionalPhoneNumber { get; set; }
}
