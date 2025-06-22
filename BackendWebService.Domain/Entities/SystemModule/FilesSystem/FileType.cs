using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("FileType")]
public class FileType : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public FileTypeEnum Type { get; set; } // Example: PDF, DOCX, JPEG

    [Required]
    public string Extentions { get; set; } // Example: .pdf,.x-pdf

    public ICollection<FileLog>? FileLogs { get; set; }
    public ICollection<FileFieldValidator>? Validators { get; set; }
}


