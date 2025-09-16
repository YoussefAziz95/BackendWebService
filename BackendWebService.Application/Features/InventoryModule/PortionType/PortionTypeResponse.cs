    using Application.Profiles;
    using Domain;

    namespace Application.Features;
    public record PortionTypeResponse(
    string Name,
    string? Description,
    string? UnitOfMeasure,
    List<PortionResponse> Portions):IConvertibleFromEntity<PortionType, PortionTypeResponse>        
    {
    public static PortionTypeResponse FromEntity(PortionType PortionType) =>
    new PortionTypeResponse(
    PortionType.Name,
    PortionType.Description,
    PortionType.UnitOfMeasure,
    PortionType.Portions.Select(PortionResponse.FromEntity).ToList()
    );
    }