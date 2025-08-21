namespace Application.Features;
public record AddressResponse(int Id,
 int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City
    );
