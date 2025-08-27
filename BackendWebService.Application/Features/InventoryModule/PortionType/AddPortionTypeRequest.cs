namespace Application.Features;
public record AddPortionTypeRequest(
string Name,
string? Description,
string? UnitOfMeasure,
List<AddPortionRequest> Portions);