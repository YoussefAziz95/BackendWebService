using Application.DTOs.Common;

namespace Application.DTOs;

public record AddProductRequest(
    string Number,
    string Name,
    string Description,
    int? FileId,
    string Code,
    string PartNumber,
    string Manufacturer,
    int CategoryId
);

public record ProductResponse(
    int? Id,
    string Number,
    string Name,
    string Description,
    FileResponse? File,
    string Code,
    string PartNumber,
    string Manufacturer,
    int CategoryId,
    bool? IsActive
);

public record UpdateProductRequest(
    int Id,
    string Number,
    string Name,
    string Description,
    int? FileId,
    string Code,
    string PartNumber,
    string Manufacturer,
    int CategoryId
);
