using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record WorkflowAllResponse([property: Required] int Id, [property: Required] string Name, [property: Required] string Description, string? WorkflowType, string? ObjectType);