namespace Application.DTOs;

public record AddPartRequest(
    string Name,
    string Description,
    string Code,
    string Image,
    string PartNumber,
    string Manufacturer,
    int ProductId
);

public record PartResponse(
    int? Id,
    string Name,
    string Description,
    string Code,
    string Image,
    string PartNumber,
    string Manufacturer,
    int ProductId,
    bool? IsActive
);

public record UpdatePartRequest(
    int Id,
    string Name,
    string Description,
    string Code,
    string Image,
    string PartNumber,
    string Manufacturer,
    int ProductId
);
