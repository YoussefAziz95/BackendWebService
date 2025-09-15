using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchWorkingHourRequest(
int BranchId,
DayOfWeek DayOfWeek,
TimeSpan OpenTime,
TimeSpan CloseTime,
bool IsClosed) : IRequest<BranchWorkingHourResponse>
{
public IValidator<BranchWorkingHourRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchWorkingHourRequest> validator)
{
throw new NotImplementedException();
}
}

