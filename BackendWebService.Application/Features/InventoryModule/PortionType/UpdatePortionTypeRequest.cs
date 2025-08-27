namespace Application.Features;
public record UpdatePortionTypeRequest(
string Name,
string? Description,
string? UnitOfMeasure,
List<UpdatePortionRequest> Portions);