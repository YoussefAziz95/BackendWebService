using Domain.Enums;

namespace Application.DTOs;

// For creating a new booking
public record BookingRequest(
    int CustomerId,
    int ServiceId,
    string Description
);

// For displaying all bookings (e.g., in a list)
public record AllBookingResponse(
    int Id,
    int CustomerId,
    int? ServiceId,
    string Description,
    string Status,             // Use the enum instead of string
    DateTime RequestedDate
);

// For a more detailed view of a booking
public record BookingResponse(
    int Id,
    int? CustomerName,
    string ServiceName,
    string ServiceCode,
    string Description,
    string Status,             // Use the enum here as well
    DateTime RequestedDate
);

// For scheduling a booking
public record ScheduleBookingRequest(
    int Id,
    DateTime ScheduledDate
);

// For assigning a technician
public record AssignTechnicianRequest(
    int TechnicianId
);
