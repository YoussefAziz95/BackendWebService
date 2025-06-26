using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("FileType")]
public class FileType : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public FileTypeEnum Type { get; set; }

    [Required]
    public string Extentions { get; set; } // should be: Extensions

    public ICollection<FileLog>? FileLogs { get; set; }
    public ICollection<FileFieldValidator>? Validators { get; set; }
}
