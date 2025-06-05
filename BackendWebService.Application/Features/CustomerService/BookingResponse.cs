using Domain.Enums;

namespace Application.Features;

public record BookingResponse(int Id, int? CustomerName, string ServiceName, string ServiceCode, string Description, StatusEnum Status, DateTime RequestedDate);