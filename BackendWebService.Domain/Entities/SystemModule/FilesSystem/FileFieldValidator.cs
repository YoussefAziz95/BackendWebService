using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("FileFieldValidator")]
public class FileFieldValidator : BaseEntity, IEntity, ITimeModification
{
    public int FileTypeId { get; set; }

    [ForeignKey(nameof(FileTypeId))]
    public FileType FileType { get; set; }

    public ValidatorEnum Validator { get; set; }
}
