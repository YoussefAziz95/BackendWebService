using Domain;

namespace Application.Features;
public record UpdateBranchesRequest(
string FranchiseName,
string? FranchiseSlogan,
    string LogoUrl,
string PhoneNumber,
string? WebsiteUrl,
List<UpdateBranchesRequest> Cafes,
List<UpdateStorageUnitRequest> StorageUnits,
List<UpdateUserRequest> Customers);