using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("FileLog")]
public class FileLog : BaseEntity, IEntity, ITimeModification   
{
    public string FileName { get; set; }
    public string FullPath { get; set; }
    public string Extention { get; set; }
    public FileTypeEnum FileType { get; set; }
}

