using Application.Validators.Common;
using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs.Companies;

public class AddCompanyRequest : BaseValidationModel<AddCompanyRequest>, ICreateMapper<Company>, ICreateMapper<Organization>
{
    [Required]
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public string TaxNo { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
    public string? Fax { get; set; }
    public string? Phone { get; set; }
    public int? RoleId { get; set; }
}
