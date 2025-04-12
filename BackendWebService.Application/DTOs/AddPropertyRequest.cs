using Application.DTOs.Addresses;

namespace BackendWebService.Application.DTOs;

public record AddPropertyRequest(
    int OwnerId,
    string Name,
    string FullAddress,
    double Latitude,
    double Longitude,
    int? fileId = null
);

public record UpdatePropertyRequest(
    int Id,
    int OwnerId,
    string Name,
    string FullAddress,
    double Latitude,
    double Longitude,
    int? fileId = null
);

public record PropertyResponse(
    int Id,
    int OwnerId,
    string Name,
    string FullAddress,
    int? fileId,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt
);