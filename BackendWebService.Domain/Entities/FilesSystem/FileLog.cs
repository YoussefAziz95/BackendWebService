using System.ComponentModel.DataAnnotations.Schema;

[Table("FileLog")]
public class FileLog : BaseEntity
{
    public string FullName { get; set; }
    public string FullPath { get; set; }
    public string Name { get; set; }
    public string Extention { get; set; }
    public int FileTypeId { get; set; }
    public FileType FileType { get; set; }
}

