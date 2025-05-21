using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("ExceptionLog")]
public class ExceptionLog : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string KeyExceptionMessage { get; set; }
    public int ExceptionCode { get; set; }
}


