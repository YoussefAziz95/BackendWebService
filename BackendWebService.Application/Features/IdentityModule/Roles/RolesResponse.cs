using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record RolesResponse(int Id, [property: Required] string Name, bool IsActive, DateTime CreatedDate, DateTime? UpdateDate);