using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record TimeSlotRequest(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId) : IRequest<TimeSlotResponse>
{
public IValidator<TimeSlotRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TimeSlotRequest> validator)
{
throw new NotImplementedException();
}
}

