using Domain;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.Entities.EmployeeModule.Franchise
{
    public class SubMenu : BaseEntity
    {
        [Required, MaxLength(100)]
        public string SubMenuName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? SubMenuDescription { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public IList<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}
