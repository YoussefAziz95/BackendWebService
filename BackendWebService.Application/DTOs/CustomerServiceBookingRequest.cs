using Domain.Enums;

namespace Application.DTOs;

public record BookingRequest(int CustomerId, int ServiceId, string Description);
public record AllBookingResponse(int Id, int? TechnicianId, int CustomerId, int ServiceId, string Description, string Status, DateTime RequestedDate);
public record BookingResponse(int Id, int? TechnicianId, int CustomerId, string ServiceName, string ServiceCode, string Description, string Status, DateTime RequestedDate);
public record ScheduleBookingRequest(int Id, DateTime ScheduledDate);
public record AssignTechnicianRequest(int TechnicianId);