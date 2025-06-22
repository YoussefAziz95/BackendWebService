using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Contact")]

public class Contact : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CompanyId { get; set; } // معرف الشركة
    public string? Value { get; set; } // القيمة (رقم الهاتف، البريد الإلكتروني، إلخ)  
    [Required]
    public string? Type { get; set; }//للاتصال  
    [NotMapped]
    public ContactEnum? ContactType => Enum.TryParse<ContactEnum>(Type, out var parsedType) ? parsedType : null;  // نوع الاتصال  


}
