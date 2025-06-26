using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Address")]
public class Address : BaseEntity, IEntity, ITimeModification
{
    public bool IsAdministration { get; set; }
    [Required]
    public string FullAddress { get; set; }
    public string? Street { get; set; }
    public string? Zone { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public void ParseAddress(string address)
    {
        var variants = address.Split('-');

        Street = variants.Length > 0 ? variants[0].Trim() : null;
        Zone = variants.Length > 1 ? variants[1].Trim() : null;
        State = variants.Length > 2 ? variants[2].Trim() : null;
        City = variants.Length > 3 ? variants[3].Trim() : null;
    }
}
