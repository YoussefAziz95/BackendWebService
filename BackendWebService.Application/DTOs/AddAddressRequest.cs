namespace Application.DTOs.Addresses;

public record AddAddressRequest(
    string FullAddress,
    string City,
    string State,
    string Country,
    string PostalCode
);

public record UpdateAddressRequest(
    int Id,
    string FullAddress,
    string City,
    string State,
    string Country,
    string? PostalCode
);

public record AddressResponse(
    int Id,
    string FullAddress,
    string City,
    string State,
    string Country,
    string PostalCode
);
