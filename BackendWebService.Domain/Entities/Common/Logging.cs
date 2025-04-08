using System.ComponentModel.DataAnnotations.Schema;

[Table("Logging")]
public class Logging : BaseEntity, IEntity, ITimeModification
{
    public int? UserId { get; set; }
    public string Message { get; set; }
    public string LogType { get; set; }
    public string? Suggestion { get; set; }
    public DateTime Timestamp { get; set; }
    public string SourceLayer { get; set; }
    public string SourceClass { get; set; }
    public int SourceLineNumber { get; set; }
}