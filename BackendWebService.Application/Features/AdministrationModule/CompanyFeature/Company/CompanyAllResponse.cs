using Domain.Enums;

namespace Application.Features;

public record CompanyAllResponse(
  int OrganizationId,
string? CompanyName,
 string? RegistrationNumber,
string? ContactEmail,
string? ContactPhone,
string? Chairman,
 string? QualityCertificates,
 string? ViceChairman,
 string? ProductType,
 StatusEnum Status
 );