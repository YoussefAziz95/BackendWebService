using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Supplier")]
public class Supplier : BaseEntity, IEntity, ITimeModification
{
    public int OrganizationId { get; set; }
    [ForeignKey("OrganizationId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Organization Organization { get; set; }
    [Precision(3, 2)]
    public decimal? Rating { get; set; }
    public string? BankAccount { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    public List<SupplierCategory> SupplierCategories { get; set; }
}