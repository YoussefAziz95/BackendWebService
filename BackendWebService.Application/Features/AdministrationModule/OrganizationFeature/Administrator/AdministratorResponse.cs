namespace Application.Features;
public record AdministratorResponse(int Id,
 bool IsAdministration,
 string Street,
 string FullAddress,
 string Zone,
 string State,
 string City);
