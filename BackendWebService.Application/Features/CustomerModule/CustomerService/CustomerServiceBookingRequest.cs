namespace Application.Features;
public record BookingRequest(int CustomerId, int ServiceId, string Description);