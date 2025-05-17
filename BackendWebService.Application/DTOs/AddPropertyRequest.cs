using Application.DTOs.Addresses;
using Domain;

namespace Application.DTOs;

public record AddPropertyRequest(
    int UserId,
    string Name,
    string ContactName,
    string ContactNumber,
    int ZoneId,
    double Latitude,
    double Longitude
);

public record UpdatePropertyRequest(
    int Id,
    int UserId,
    string Name,
    string ContactName,
    string ContactNumber,
    int ZoneId,
    double Latitude,
    double Longitude
);

public record PropertyResponse(
    int Id,
    int UserId,
    string Name,
    string ContactName,
    string ContactNumber,
    string ZoneName,
    double Latitude,
    double Longitude,
    DateTimeOffset CreatedAt
);
public record PropertyListResponse(
    int Id,
    string Name,
    string ContactName,
    string ContactNumber,
    string ZoneName,
    double Latitude,
    double Longitude
);