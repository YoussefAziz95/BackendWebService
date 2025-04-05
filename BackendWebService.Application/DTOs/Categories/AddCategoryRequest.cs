using Application.Validators.Common;
using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Categories;

public class AddCategoryRequest : BaseValidationModel<AddCategoryRequest>, ICreateMapper<Category>
{
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
