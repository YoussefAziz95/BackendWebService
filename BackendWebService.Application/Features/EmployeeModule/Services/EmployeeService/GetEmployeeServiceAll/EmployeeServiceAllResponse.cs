using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmployeeServiceAllResponse(
int? EmployeeId,
int? CustomerServiceId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
string Description,
string? AdditionalPhoneNumber) : IConvertibleFromEntity<EmployeeService, EmployeeServiceAllResponse>
{
    public static EmployeeServiceAllResponse FromEntity(EmployeeService EmployeeService) =>
    new EmployeeServiceAllResponse(
    EmployeeService.EmployeeId,
    EmployeeService.CustomerServiceId,
    EmployeeService.Notes,
    EmployeeService.VoiceNoteId,
    EmployeeService.FilesId,
    EmployeeService.Description,
    EmployeeService.AdditionalPhoneNumber);
}

