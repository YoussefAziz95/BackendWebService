using Application.Features;

namespace BackendWebService.Application.Features.AdministrationModule.ConsumerFeature.Consumer;

public record ConsumerCustomerAllResponse(
    AddOrganizationRequest Organization,
    int SupplierId,
    int CategoryId
// consumer customer all response
);