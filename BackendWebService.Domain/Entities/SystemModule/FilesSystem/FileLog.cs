using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("FileLog")]
public class FileLog : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string FileName { get; set; }

    [Required]
    public string FullPath { get; set; }

    [Required]
    public string Extention { get; set; }

    public int FileTypeId { get; set; }

    [ForeignKey(nameof(FileTypeId))]
    public FileType FileType { get; set; }
}
