using Application.Profiles;
using Domain;

namespace Application.Features;
public record EmployeeServiceResponse(
int? EmployeeId,
int? CustomerServiceId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
string Description,
string? AdditionalPhoneNumber) : IConvertibleFromEntity<EmployeeService, EmployeeServiceResponse>
{
public static EmployeeServiceResponse FromEntity(EmployeeService EmployeeService) =>
new EmployeeServiceResponse(
EmployeeService.EmployeeId,
EmployeeService.CustomerServiceId,
EmployeeService.Notes,
EmployeeService.VoiceNoteId,
EmployeeService.FilesId,
EmployeeService.Description,
EmployeeService.AdditionalPhoneNumber);
}