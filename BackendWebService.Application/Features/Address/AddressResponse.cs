namespace Application.Features;

public record AddressResponse(int Id,
 bool IsAdministration,
 string Stree,
 string Zone,
 string State,
 string City);
