using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Categories;

public class CategoryResponse : ICreateMapper<Category>
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public bool? IsActive { get; set; }
}
