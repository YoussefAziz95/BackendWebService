using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Contact")]

public class Contact : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public new int OrganizationId { get; set; }
    public string? Value { get; set; }
    [Required]
    public string? Type { get; set; }
    [NotMapped]
    public ContactEnum? ContactType => Enum.TryParse<ContactEnum>(Type, out var parsedType) ? parsedType : null;
}
