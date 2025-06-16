using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum ActorEnum
    {
        [Display(Description = "مستخدم")]
        User = 1,

        [Display(Description = "دور")]
        Role = 2,

        [Display(Description = "مجموعة")]
        Group = 3,
    }
}
