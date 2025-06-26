using Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public FileLog File { get; set; }

    [ForeignKey(nameof(FileFieldValidatorId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public FileFieldValidator FileFieldValidator { get; set; }
}
