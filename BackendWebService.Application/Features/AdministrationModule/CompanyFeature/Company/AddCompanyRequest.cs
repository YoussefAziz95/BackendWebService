
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddCompanyRequest(
 int OrganizationId,
string? CompanyName,
 string? RegistrationNumber,
string? ContactEmail,
string? ContactPhone,
string? Chairman,
 string? QualityCertificates,
 string? ViceChairman,
 string? ProductType,
 StatusEnum Status,
 List<AddCompanyCategoryRequest> Category,
 List<AddManagerRequest> Manager
);
