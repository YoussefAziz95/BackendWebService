using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Attachment")]
public class Attachment : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int EmailId { get; set; }

    [Required]
    public int FileId { get; set; }

    [Required]
    public int FileFieldValidatorId { get; set; }

    [ForeignKey(nameof(EmailId))]
    public EmailLog Email { get; set; }

    [ForeignKey(nameof(FileId))]
    public FileLog File { get; set; }

    [ForeignKey(nameof(FileFieldValidatorId))]
    public FileFieldValidator FileFieldValidator { get; set; }
}

