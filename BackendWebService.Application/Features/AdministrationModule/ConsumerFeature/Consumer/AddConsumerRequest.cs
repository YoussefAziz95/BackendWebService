using Application.Features;
using Microsoft.EntityFrameworkCore;

namespace BackendWebService.Application.Features.AdministrationModule.ConsumerFeature.Consumer;
public record AddConsumerRequest(
    int OrganizationId,
    string BankAccount, 
    decimal? Rating,
    List<AddConsumerAccountRequest> ConsumerAccounts
);
