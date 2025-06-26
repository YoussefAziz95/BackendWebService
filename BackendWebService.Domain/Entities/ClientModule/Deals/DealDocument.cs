using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("DealDocument")]
public class DealDocument : BaseEntity, IEntity, ITimeModification
{
    [Range(1, 100)]
    public int? Score { get; set; }

    public string? Comment { get; set; }

    public string? RichText { get; set; }

    public int? StatusId { get; set; }

    public int DealId { get; set; }

    public int CriteriaId { get; set; }

    public int FileId { get; set; }

    public int FileFieldValidatorId { get; set; }

    [ForeignKey(nameof(DealId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Deal Deal { get; set; }

    [ForeignKey(nameof(CriteriaId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Criteria Criteria { get; set; }

    [ForeignKey(nameof(FileId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public FileLog File { get; set; }

    [ForeignKey(nameof(FileFieldValidatorId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public FileFieldValidator FileFieldValidator { get; set; }
}
