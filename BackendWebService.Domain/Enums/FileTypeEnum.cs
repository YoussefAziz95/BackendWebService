using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum FileTypeEnum
{

    [Display(Name = "Video", Description = "فيديو")]
    Video = 1,

    [Display(Name = "Audio", Description = "ملف صوتي")]
    Audio = 2,

    [Display(Name = "Document", Description = "مستند")]
    Document = 3,

    [Display(Name = "Archive", Description = "أرشيف مضغوط")]
    Archive = 4,

    [Display(Name = "Executable", Description = "ملف تنفيذي")]
    Executable = 5,

    [Display(Name = "Other", Description = "نوع آخر")]
    Other = 6,

    [Display(Name = "Image", Description = "صورة")]
    Image = 7
}
