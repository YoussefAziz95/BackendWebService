using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Technician")]
public class Technician
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; }
    [Required, Phone, MaxLength(20)]
    public string PhoneNumber { get; set; }
    [Required]
    public string PasswordHash { get; set; }  // Securely stored password
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public StatusEnum AccountStatus { get; set; } = StatusEnum.Pending; // Default status
    public RoleEnum Role { get; set; } = RoleEnum.Technician;
}