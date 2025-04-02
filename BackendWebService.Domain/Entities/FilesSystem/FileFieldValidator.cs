using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

[Table("FileFieldValidator")]
public class FileFieldValidator : BaseEntity
{
    public int FileTypeId { get; set; }
    public ValidatorEnum Validator { get; set; }
}