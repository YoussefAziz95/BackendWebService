using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum ValidatorEnum
{
    [Display(Name = "None", Description = "بدون تحقق")]
    None = 0,

    [Display(Name = "Required", Description = "حقل مطلوب")]
    Required = 1,

    [Display(Name = "Email", Description = "صيغة بريد إلكتروني صحيحة")]
    Email = 2,

    [Display(Name = "Phone", Description = "رقم هاتف صحيح")]
    Phone = 3,

    [Display(Name = "StringLength", Description = "التحقق من طول النص")]
    StringLength = 4,

    [Display(Name = "MaxLength", Description = "الحد الأقصى للطول")]
    MaxLength = 5,

    [Display(Name = "MinLength", Description = "الحد الأدنى للطول")]
    MinLength = 6,

    [Display(Name = "Range", Description = "قيمة داخل نطاق محدد")]
    Range = 7,

    [Display(Name = "RegularExpression", Description = "مطابقة مع نمط معين")]
    RegularExpression = 8,

    [Display(Name = "Compare", Description = "مقارنة مع قيمة أخرى")]
    Compare = 9,

    [Display(Name = "CreditCard", Description = "رقم بطاقة ائتمان صالح")]
    CreditCard = 10,

    [Display(Name = "DataType", Description = "نوع بيانات محدد")]
    DataType = 11,

    [Display(Name = "Display", Description = "إعدادات العرض")]
    Display = 12,

    [Display(Name = "EnumDataType", Description = "نوع بيانات تعداد")]
    EnumDataType = 13,

    [Display(Name = "FileExtensions", Description = "امتدادات ملفات محددة")]
    FileExtensions = 14,

    [Display(Name = "Max", Description = "قيمة قصوى")]
    Max = 15,

    [Display(Name = "Min", Description = "قيمة دنيا")]
    Min = 16,

    [Display(Name = "Url", Description = "رابط إلكتروني صالح")]
    Url = 17,

    [Display(Name = "Key", Description = "المفتاح الأساسي")]
    Key = 18,

    [Display(Name = "ConcurrencyCheck", Description = "التحقق من التزامن")]
    ConcurrencyCheck = 19,

    [Display(Name = "DatabaseGenerated", Description = "مولد من قاعدة البيانات")]
    DatabaseGenerated = 20,

    [Display(Name = "ForeignKey", Description = "مفتاح خارجي")]
    ForeignKey = 21,

    [Display(Name = "InverseProperty", Description = "الخاصية العكسية للربط")]
    InverseProperty = 22,
}
