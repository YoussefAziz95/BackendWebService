using Application.Features;
using Domain.Enums;

namespace Application.Features;
public record ConsumerResponse(
 int OrganizationId,
 string BankAccount,
 decimal? Rating,
 StatusEnum Status,
 List<ConsumerCustomerResponse> ConsumerCustomer,
 List<ConsumerAccountResponse> ConsumerAccounts
);