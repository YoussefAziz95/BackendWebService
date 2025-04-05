using Application.Validators.Common;
using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Categories;

public class UpdateCategoryRequest : BaseValidationModel<UpdateCategoryRequest>, ICreateMapper<Category>
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
