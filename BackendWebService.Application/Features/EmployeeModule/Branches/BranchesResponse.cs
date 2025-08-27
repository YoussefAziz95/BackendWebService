using Domain;

namespace Application.Features;
public record BranchesResponse(
 string FranchiseName,
    string? FranchiseSlogan,
     string LogoUrl,
   string PhoneNumber,
    string? WebsiteUrl,
    List<AddBranchesRequest> Cafes,
    List<AddStorageUnitRequest> StorageUnits,
    List<UpdateUserRequest> Customers
    );