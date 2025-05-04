using Application.DTOs.Addresses;
using Domain;

namespace Application.DTOs;

public record AddPropertyRequest(
    int UserId,
    string Name,
    string FullAddress,
    double Latitude,
    double Longitude,
    string ZoneName,
    string ContactNumber,
    int? BuildingNumber,
    int? FloorNumber,
    int? ApartmentNumber,
    int? StreetNumber
);

public record UpdatePropertyRequest(
    int Id,
    int UserId,
    string Name,
    string FullAddress,
    string? ZoneName,
    double Latitude,
    double Longitude,
    string ContactNumber,
    int? BuildingNumber,
    int? FloorNumber,
    int? ApartmentNumber,
    int? StreetNumber
);

public record PropertyResponse(
    int Id,
    int UserId,
    string Name,
    string FullAddress,
    string? ZoneName,
    string ContactNumber,
    int? BuildingNumber,
    int? FloorNumber,
    int? ApartmentNumber,
    int? StreetNumber,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt
);