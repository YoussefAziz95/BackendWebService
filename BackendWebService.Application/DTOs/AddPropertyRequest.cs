using Application.DTOs.Addresses;

namespace BackendWebService.Application.DTOs;

public record AddPropertyRequest(
    int OwnerId,
    string Name,
    string FullAddress,
    double Latitude,
    double Longitude
);

public record UpdatePropertyRequest(
    int Id,
    int OwnerId,
    string Name,
    string FullAddress,
    double Latitude,
    double Longitude
);

public record PropertyResponse(
    int Id,
    int OwnerId,
    string Name,
    string FullAddress,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt
);