using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Organization")]
public class Organization : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public OrganizationEnum Type { get; set; }
    public string FaxNo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string TaxNo { get; set; }
    public int FileId { get; set; }
    [ForeignKey("FileId")]
    public FileLog File { get; set; }
}