using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("CompanyCategory")]
public class CompanyCategory : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CompanyId { get; set; } // معرف الشركة

    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; } // الشركة المرتبطة بالنشاط

    [Required]
    public int CategoryId { get; set; } // اسم النشاط

    // This assumes Category.Name is the primary or unique key
    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; } // النشاط

}
