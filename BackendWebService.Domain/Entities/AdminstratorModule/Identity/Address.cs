using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Address")]
public class Address : BaseEntity, IEntity, ITimeModification
{

    [Required, MaxLength(255)]
    public string FullAddress { get; set; }
    [Required, MaxLength(100)]
    public string City { get; set; }
    [Required, MaxLength(100)]
    public string State { get; set; }
    [Required, MaxLength(100)]
    public string Country { get; set; }
    [MaxLength(20)]
    public string PostalCode { get; set; }
}