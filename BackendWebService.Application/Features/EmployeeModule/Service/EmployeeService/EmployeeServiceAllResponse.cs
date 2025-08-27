using Domain.Enums;

namespace Application.Features;
public record EmployeeServiceAllResponse(
int? EmployeeId,
int? CustomerServiceId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
string Description,
string? AdditionalPhoneNumber);

