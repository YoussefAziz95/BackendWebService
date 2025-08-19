using Application.Features;

namespace BackendWebService.Application.Features.AdministrationModule.ConsumerFeature.Consumer;

public record ConsumerAllResponse(
    AddOrganizationRequest Organization,
    string BankAccount, 
    decimal? Rating
    // consumer account all response
);