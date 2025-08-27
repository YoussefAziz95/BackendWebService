using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowAllResponse(
string? Name,
string? Description,
int UserId,
int CompanyId);