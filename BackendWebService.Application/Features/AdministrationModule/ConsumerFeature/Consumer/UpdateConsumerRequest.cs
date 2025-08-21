using Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerRequest(
int OrganizationId,
 string BankAccount,
 decimal? Rating,
 StatusEnum Status,
 List<AddConsumerCustomerRequest> AddConsumerCustomer,
 List<AddConsumerAccountRequest> ConsumerAccounts
    );