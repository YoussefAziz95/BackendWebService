using Domain.Enums;

namespace Application.DTOs;

public record BookingRequest(int CustomerId, int CategoryId, string Description);
public record BookingResponse(int Id, int CustomerId, string Description, StatusEnum Status, DateTime RequestedDate);
public record ScheduleBookingRequest(int Id, DateTime ScheduledDate);
public record AssignTechnicianRequest(int TechnicianId);