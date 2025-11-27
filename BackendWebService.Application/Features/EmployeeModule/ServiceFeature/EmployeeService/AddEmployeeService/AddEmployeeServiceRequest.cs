using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddEmployeeServiceRequest(
int? EmployeeId,
int? CustomerServiceId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
string Description,
string? AdditionalPhoneNumber) : IConvertibleToEntity<EmployeeService>, IRequest<int>
{
    public EmployeeService ToEntity() => new EmployeeService
    {
        EmployeeId = EmployeeId,
        CustomerServiceId = CustomerServiceId,
        Notes = Notes,
        VoiceNoteId = VoiceNoteId,
        FilesId = FilesId,
        Description = Description,
        AdditionalPhoneNumber = AdditionalPhoneNumber
    };
}