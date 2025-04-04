using Application.DTOs.SupplierCategories;
using BackendWebService.Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs.Auths;

public class RegisterSupplierRequest : ICreateMapper<Supplier>, ICreateMapper<Organization>
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

    public string? Department { get; set; }

    public string? Title { get; set; }

    public bool IsDocumentsApproved { get; set; } = false;

    public bool IsApproved { get; set; } = false;

    public List<AddSupplierCategoryRequest>? Categories { get; set; }
}
