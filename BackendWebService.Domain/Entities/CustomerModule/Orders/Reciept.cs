using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Receipt : BaseEntity
{
    [Required]
    public List<Order> Orders { get; set; } = new();

    [Required]
    public PaymentMethod PaymentMethod { get; set; }
}
