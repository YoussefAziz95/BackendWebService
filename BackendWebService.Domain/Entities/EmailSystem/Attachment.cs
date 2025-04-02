
using System.ComponentModel.DataAnnotations.Schema;


[Table("Attachment")]
public class Attachment : BaseEntity
{
    public int EmailId { get; set; }
    public int FileId { get; set; }
    public int FileFieldValidatorId { get; set; }
    public EmailLog Email { get; set; }
    public FileLog File { get; set; }
    public FileFieldValidator FileFieldValidator { get; set; }
}

