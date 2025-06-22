using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Menu : BaseEntity
{
    public virtual List<SubMenu> SubMenus { get; set; } = new();

    [Range(0, 100)]
    public int TaxInPercent { get; set; }

    [Range(0, 100)]
    public int ServiceInPercent { get; set; }
}
