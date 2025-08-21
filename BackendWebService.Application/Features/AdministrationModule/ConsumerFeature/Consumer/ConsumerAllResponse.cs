using Application.Features;
using Domain.Enums;

namespace Application.Features;

public record ConsumerAllResponse(
   int OrganizationId,
    string BankAccount,
    decimal? Rating,
    StatusEnum Status

);