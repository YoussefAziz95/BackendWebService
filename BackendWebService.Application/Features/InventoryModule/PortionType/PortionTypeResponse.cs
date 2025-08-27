namespace Application.Features;
public record PortionTypeResponse(
string Name,
string? Description,
string? UnitOfMeasure,
List<PortionResponse> Portions);