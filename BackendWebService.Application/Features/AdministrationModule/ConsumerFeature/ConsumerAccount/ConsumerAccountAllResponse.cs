using Application.Features;

namespace Application.Features;

public record ConsumerAccountAllResponse(
   int CompanyId,
    int ConsumerId,
    bool IsApproved,
    DateTime? ApprovedDate
);