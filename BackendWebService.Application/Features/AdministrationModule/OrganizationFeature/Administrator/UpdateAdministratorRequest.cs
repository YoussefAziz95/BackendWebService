namespace Application.Features;
public record UpdateAdministratorRequest(
int Id,
string FullAddress,
string Street,
string Zone,
string State,
string? City);
