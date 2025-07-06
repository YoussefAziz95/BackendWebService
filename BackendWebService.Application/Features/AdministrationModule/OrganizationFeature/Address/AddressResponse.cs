namespace Application.Features;
public record AddressResponse(int Id,
 bool IsAdministration,
 string Street,
 string FullAddress,
 string Zone,
 string State,
 string City);
