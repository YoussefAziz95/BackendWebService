using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record UpdateCaseActionRequest(int Id, [property: Required] string ObjectType, [property: Required] int ObjectId, int? StatusId, string? Comment, int? Score, string? ActionType);