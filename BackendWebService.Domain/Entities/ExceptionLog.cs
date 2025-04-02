using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ExceptionLog")]
public class ExceptionLog : BaseEntity
{
    [Required]
    public string KeyExceptionMessage { get; set; }
    public int ExceptionCode { get; set; }
}
    

