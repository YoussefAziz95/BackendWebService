namespace Application.Features;

public record AddPartRequest(
    string Name,
    string Description,
    string Code,
    string Image,
    string PartNumber,
    string Manufacturer,
    int ProductId);