using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("FileLog")]
public class FileLog : BaseEntity, IEntity, ITimeModification   
{
    public string FullName { get; set; }
    public string FullPath { get; set; }
    public string Name { get; set; }
    public string Extention { get; set; }
    public int FileTypeId { get; set; }
    public FileType FileType { get; set; }
}

