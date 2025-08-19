using Application.Features;

namespace BackendWebService.Application.Features.AdministrationModule.ConsumerFeature.Consumer;
public record ConsumerAccountResponse(
    int Id,
    string Name,
    string Country,
    string City,
    string StreetAddress,
    string Email,
    string TaxNo,
    string? Phone,
    int? FileId,
    string? ImageUrl,
    string? Fax,
    string RoleType,
    bool? IsActive,
    DateTime? CreatedDate,
    DateTime? UpdateDate,
    List<AddressResponse> Addresses,
    List<ContactResponse> Contacts
);