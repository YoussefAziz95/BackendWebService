using Domain.Enums;

namespace Application.Features;

public record AllBookingResponse(
int Id,
int CustomerId,
int? ServiceId,
string Description,
StatusEnum Status,
DateTime RequestedDate);