

using Domain.Enums;

namespace Application.Features;
public record AddConsumerRequest(
    int OrganizationId,
    string BankAccount, 
    decimal? Rating,
    StatusEnum Status,
    List<AddConsumerCustomerRequest> AddConsumerCustomer,
    List<AddConsumerAccountRequest> ConsumerAccounts
);
