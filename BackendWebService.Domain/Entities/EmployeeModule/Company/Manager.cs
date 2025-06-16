using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Managers")]
public class Manager : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CompanyId { get; set; } // معرف الشركة

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } // اسم المدير

    [NotMapped]
    public RoleEnum? ManagerType => Enum.TryParse<RoleEnum>(Position, out var parsedType) ? parsedType : null;  // نوع المدير

    [Required]
    public string Position { get; set; }  // المنصب - يحسب ولا يُخزن
}